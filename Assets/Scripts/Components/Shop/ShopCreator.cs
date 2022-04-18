using System;
using AreYouFruits.Common.ComponentGeneration;
using Components.Customization;
using GachiBird.Customization;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Shop
{
    public class ShopCreator : MonoBehaviour
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;

        [Header("Objects")] 
        [SerializeField] private RectTransform _playerSkinsLotsParentObject;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        [Header("Prefabs")] 
        [SerializeField] private GameObject _lotPrefab;
#nullable enable

        private void Start()
        {
            CreatePlayerSkinShop();
        }

        private void CreatePlayerSkinShop()
        {
            PlayerSkinInfo[] playerSkinInfos = _playerCustomizer.GetHeldItem().PlayerSkinInfoArray;
            var amountOfRows = (int) Math.Ceiling(playerSkinInfos.Length / 2f);
            _playerSkinsLotsParentObject.sizeDelta = new Vector2(
                Screen.width, 
                _gridLayoutGroup.cellSize.y * amountOfRows + _gridLayoutGroup.spacing.y * (amountOfRows + 1) 
            );
            foreach (PlayerSkinInfo playerSkinInfo in playerSkinInfos)
            {
                GameObject newLot = Instantiate(_lotPrefab, _playerSkinsLotsParentObject);
                newLot.GetComponent<Lot>().Setup(playerSkinInfo);
            }
        }
    }
}