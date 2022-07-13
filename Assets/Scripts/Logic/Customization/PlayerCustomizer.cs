using System;
using System.Collections.Generic;
using GachiBird.Game;
using GachiBird.Serialization;
using GachiBird.UserInterface.Shop;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizer : IPlayerCustomizer
    {
        private readonly IGameSaverLoader _gameSaverLoader;
        private readonly IMoneyHolder _moneyHolder;
        private readonly IApprover _approver;

        private readonly SpriteRenderer _spriteRenderer;

        public PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        public event Action<PlayerSkinInfo>? OnPlayerSkinSelect;
        public event Action<PlayerSkinInfo>? OnPlayerSkinPurchase;

        public PlayerCustomizer(
            IGameSaverLoader gameSaverLoader, IMoneyHolder moneyHolder, IApprover approver,
            SpriteRenderer spriteRenderer, PlayerSkinInfo[] playerSkins
        )
        {
            _gameSaverLoader = gameSaverLoader;
            _moneyHolder = moneyHolder;
            _approver = approver;
            _spriteRenderer = spriteRenderer;
            PlayerSkinInfoArray = playerSkins;

            int currentSkinId = _gameSaverLoader.SkinId;
            SelectPlayerSkin(PlayerSkinInfoArray[currentSkinId]);
        }

        public void TryToChangeSkin(PlayerSkinInfo playerSkinInfo)
        {
            if (IsLotAlreadyChosen(playerSkinInfo))
            {
                return;
            }

            if (TryToSelectSkin(playerSkinInfo))
            {
                return;
            }

            TryToBuySkin(playerSkinInfo);
        }

        private bool IsLotAlreadyChosen(PlayerSkinInfo playerSkinInfo)
        {
            return _gameSaverLoader.SkinId == playerSkinInfo.Id;
        }

        private bool TryToSelectSkin(PlayerSkinInfo playerSkinInfo)
        {
            if (_gameSaverLoader.SkinStatus[playerSkinInfo.Id])
            {
                SelectPlayerSkin(playerSkinInfo);

                return true;
            }

            return false;
        }

        private void TryToBuySkin(PlayerSkinInfo playerSkinInfo)
        {
            if (_moneyHolder.Money >= playerSkinInfo.Price)
            {
                _approver.CallForApproval(playerSkinInfo);
                _approver.OnApproval += () => BuySkin(playerSkinInfo);
            }
        }

        private void BuySkin(PlayerSkinInfo playerSkinInfo)
        {
            var statusOfSkins = new Dictionary<int, bool>(_gameSaverLoader.SkinStatus);
            statusOfSkins[playerSkinInfo.Id] = true;
            _gameSaverLoader.SkinStatus = statusOfSkins;

            _moneyHolder.Money -= playerSkinInfo.Price;

            SelectPlayerSkin(playerSkinInfo);
            OnPlayerSkinPurchase?.Invoke(playerSkinInfo);
        }

        private void SelectPlayerSkin(PlayerSkinInfo playerSkinInfo)
        {
            _gameSaverLoader.SkinId = playerSkinInfo.Id;

            OnPlayerSkinSelect?.Invoke(playerSkinInfo);
            _spriteRenderer.sprite = PlayerSkinInfoArray[playerSkinInfo.Id].Sprite;
        }

        public bool IsSkinSelected(int skinId)
        {
            return skinId == _gameSaverLoader.SkinId;
        }

        public bool IsSkinLocked(int skinId)
        {
            return !_gameSaverLoader.SkinStatus[skinId];
        }
    }
}
