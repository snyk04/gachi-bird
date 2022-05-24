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
        private readonly IGameSaver _gameSaver;
        private readonly IMoneyHolder _moneyHolder;
        private readonly IApprover _approver;
        
        private readonly SpriteRenderer _spriteRenderer;

        public PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        public event Action<PlayerSkinInfo>? OnPlayerSkinSelect;
        public event Action<PlayerSkinInfo>? OnPlayerSkinPurchase;
        
        public PlayerCustomizer(IGameSaver gameSaver, IMoneyHolder moneyHolder, IApprover approver,
            SpriteRenderer spriteRenderer, PlayerSkinInfo[] playerSkins)
        {
            _gameSaver = gameSaver;
            _moneyHolder = moneyHolder;
            _approver = approver;
            _spriteRenderer = spriteRenderer;
            PlayerSkinInfoArray = playerSkins;

            int currentSkinId = _gameSaver.LoadCurrentSkinId();
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
            return _gameSaver.LoadCurrentSkinId() == playerSkinInfo.Id;
        }
        private bool TryToSelectSkin(PlayerSkinInfo playerSkinInfo)
        {
            if (_gameSaver.LoadStatusOfSkins()[playerSkinInfo.Id])
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
            Dictionary<int, bool> statusOfSkins = _gameSaver.LoadStatusOfSkins();
            statusOfSkins[playerSkinInfo.Id] = true;
            _gameSaver.SaveStatusOfSkins(statusOfSkins);
            
            _moneyHolder.Money -= playerSkinInfo.Price;
            
            SelectPlayerSkin(playerSkinInfo);
            OnPlayerSkinPurchase?.Invoke(playerSkinInfo);
        }
        private void SelectPlayerSkin(PlayerSkinInfo playerSkinInfo)
        {
            _gameSaver.SaveCurrentSkinId(playerSkinInfo.Id);
            
            OnPlayerSkinSelect?.Invoke(playerSkinInfo);
            _spriteRenderer.sprite = PlayerSkinInfoArray[playerSkinInfo.Id].Sprite;
        }

        public bool IsSkinSelected(int skinId)
        {
            return skinId == _gameSaver.LoadCurrentSkinId();
        }
        public bool IsSkinLocked(int skinId)
        {
            return !_gameSaver.LoadStatusOfSkins()[skinId];
        }
    }
}