using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using UnityEngine;

namespace Components.Shop
{
    public class ShopCreator : MonoBehaviour
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;
#nullable enable

        private void Start()
        {
            CreatePlayerSkinShop();
        }

        private void CreatePlayerSkinShop()
        {
            foreach (PlayerSkinInfo playerSkinInfo in _playerCustomizer.GetHeldItem().PlayerSkinInfoArray)
            {
                Debug.Log(playerSkinInfo.Name);
            }
        }
    }
}