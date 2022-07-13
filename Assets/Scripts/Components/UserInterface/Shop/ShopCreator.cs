using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserInterface.Shop
{
    public class ShopCreator : MonoBehaviour
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;
        [SerializeField] private SerializedInterface<IComponent<IGameSaverLoader>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IMoneyHolder>> _moneyHolder;
        [SerializeField] private SerializedInterface<IComponent<IApprover>> _approver;

        [Header("Objects")] 
        [SerializeField] private RectTransform _playerSkinsLotsParentObject;

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
            CreateLots(playerSkinInfos);
        }
        private void CreateLots(IEnumerable<PlayerSkinInfo> playerSkinInfos)
        {
            foreach (PlayerSkinInfo playerSkinInfo in playerSkinInfos)
            {
                CreateLot(playerSkinInfo);
            }
        }
        private void CreateLot(PlayerSkinInfo playerSkinInfo)
        {
            GameObject lotObject = Instantiate(_lotPrefab, _playerSkinsLotsParentObject);
            ILot lot = lotObject.GetComponent<LotСomponent>().HeldItem;
                
            lot.Setup(_playerCustomizer.GetHeldItem(), playerSkinInfo);

            if (!_gameSaver.GetHeldItem().SkinStatus.ContainsKey(playerSkinInfo.Id))
            {
                var statusOfSkins = new Dictionary<int, bool>(_gameSaver.GetHeldItem().SkinStatus);
                statusOfSkins.Add(playerSkinInfo.Id, false);
                _gameSaver.GetHeldItem().SkinStatus = statusOfSkins;
            }
        }
    }
}