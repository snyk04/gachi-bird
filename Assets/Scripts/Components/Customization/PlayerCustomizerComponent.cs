using System.Linq;
using AreYouFruits.Common.ComponentGeneration;
using Components.Shop;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizerComponent : AbstractComponent<PlayerCustomizer>
    {
#nullable disable
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PlayerSkinSettings[] _playerSkinSettingsArray;
#nullable enable
        
        protected override PlayerCustomizer Create()
        {
            return new PlayerCustomizer(
                _spriteRenderer,
                _playerSkinSettingsArray.Select(playerSkinSettings => playerSkinSettings.PlayerSkinInfo).ToArray()
                );
        }
    }
}