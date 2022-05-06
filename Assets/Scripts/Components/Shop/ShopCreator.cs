using System;
using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using Components.Customization;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;
using GachiBird.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Shop
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
            int amountOfRows = (int) Math.Ceiling(playerSkinInfos.Length / 2f);
            _playerSkinsLotsParentObject.sizeDelta = new Vector2(
                Screen.width,
                _gridLayoutGroup.cellSize.y * amountOfRows + _gridLayoutGroup.spacing.y * (amountOfRows + 1)
            );

            int currentSkinId = _gameSaver.GetHeldItem().LoadCurrentSkinId();
            Dictionary<int, bool> statusOfSkins = _gameSaver.GetHeldItem().LoadStatusOfSkins();

            foreach (PlayerSkinInfo playerSkinInfo in playerSkinInfos)
            {
                GameObject lotObject = Instantiate(_lotPrefab, _playerSkinsLotsParentObject);
                ILot lot = lotObject.GetComponent<LotСomponent>().HeldItem;
                
                lot.Setup(_gameSaver.GetHeldItem(), _moneyHolder.GetHeldItem(),
                    _playerCustomizer.GetHeldItem(), playerSkinInfo);
                lot.OnSelect += lot1 =>
                {
                    _lastSelectedLot?.Deselect();
                    _lastSelectedLot = lot1;
                };

                if (currentSkinId == playerSkinInfo.Id)
                {
                    lot.Select();
                    _lastSelectedLot = lot;
                }

                if (statusOfSkins.ContainsKey(playerSkinInfo.Id))
                {
                    if (statusOfSkins[playerSkinInfo.Id])
                    {
                        lot.Unlock();
                    }
                    else
                    {
                        lot.Lock();
                    }
                }
                else
                {
                    lot.Lock();
                }
            }
        }
    }
}