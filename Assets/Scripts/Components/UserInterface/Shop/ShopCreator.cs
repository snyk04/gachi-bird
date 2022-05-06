using System;
using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using Components.Customization;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class ShopCreator : MonoBehaviour
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IMoneyHolder>> _moneyHolder;

        [Header("Objects")] 
        [SerializeField] private RectTransform _playerSkinsLotsParentObject;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        [Header("Prefabs")] 
        [SerializeField] private GameObject _lotPrefab;
#nullable enable

        private ILot? _lastSelectedLot;

        private void Start()
        {
            CreatePlayerSkinShop();
        }

        private void CreatePlayerSkinShop()
        {
            PlayerSkinInfo[] playerSkinInfos = _playerCustomizer.GetHeldItem().PlayerSkinInfoArray;
            int currentSkinId = _gameSaver.GetHeldItem().LoadCurrentSkinId();
            Dictionary<int, bool> statusOfSkins = _gameSaver.GetHeldItem().LoadStatusOfSkins();
            
            SetPlayerSkinShopPageSize(playerSkinInfos);
            CreateLots(playerSkinInfos, currentSkinId, statusOfSkins);
        }

        private void SetPlayerSkinShopPageSize(IReadOnlyCollection<PlayerSkinInfo> playerSkinInfos)
        {
            int amountOfRows = (int) Math.Ceiling(playerSkinInfos.Count / 2f);
            _playerSkinsLotsParentObject.sizeDelta = new Vector2(
                Screen.width,
                _gridLayoutGroup.cellSize.y * amountOfRows + _gridLayoutGroup.spacing.y * (amountOfRows + 1)
            );
        }
        private void CreateLots(IEnumerable<PlayerSkinInfo> playerSkinInfos, int currentSkinId,
             IReadOnlyDictionary<int, bool> statusOfSkins)
        {
            foreach (PlayerSkinInfo playerSkinInfo in playerSkinInfos)
            {
                CreateLot(playerSkinInfo, out ILot lot);
                SetLotSelection(lot, currentSkinId, playerSkinInfo);
                SetLotLock(lot, statusOfSkins, playerSkinInfo);
            }
        }

        private void CreateLot(PlayerSkinInfo playerSkinInfo, out ILot lot)
        {
            GameObject lotObject = Instantiate(_lotPrefab, _playerSkinsLotsParentObject);
            lot = lotObject.GetComponent<LotСomponent>().HeldItem;
                
            lot.Setup(_gameSaver.GetHeldItem(), _moneyHolder.GetHeldItem(), _playerCustomizer.GetHeldItem(), playerSkinInfo);
            lot.OnSelect += selectedLot =>
            {
                _lastSelectedLot?.SetSelect(false);
                _lastSelectedLot = selectedLot;
            };
            
            if (!_gameSaver.GetHeldItem().LoadStatusOfSkins().ContainsKey(playerSkinInfo.Id))
            {
                Dictionary<int, bool> statusOfSkins = _gameSaver.GetHeldItem().LoadStatusOfSkins();
                statusOfSkins.Add(playerSkinInfo.Id, false);
                _gameSaver.GetHeldItem().SaveStatusOfSkins(statusOfSkins);
            }
        }
        private void SetLotSelection(ILot lot, int currentSkinId, PlayerSkinInfo playerSkinInfo)
        {
            if (currentSkinId == playerSkinInfo.Id)
            {
                lot.SetSelect(true);
                _lastSelectedLot = lot;
            }
        }
        private void SetLotLock(ILot lot, IReadOnlyDictionary<int, bool> statusOfSkins, PlayerSkinInfo playerSkinInfo)
        {
            if (playerSkinInfo.Id == _gameSaver.GetHeldItem().LoadCurrentSkinId())
            {
                lot.SetLock(false);
                return;
            }
            
            if (statusOfSkins.ContainsKey(playerSkinInfo.Id))
            {
                lot.SetLock(!statusOfSkins[playerSkinInfo.Id]);
            }
            else
            {
                lot.SetLock(true);
            }
        }
    }
}