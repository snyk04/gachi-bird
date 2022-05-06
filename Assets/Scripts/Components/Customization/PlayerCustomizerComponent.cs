using System.Linq;
using AreYouFruits.Common.ComponentGeneration;
using Components.Customization;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizerComponent : AbstractComponent<PlayerCustomizer>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PlayerSkinSettings[] _playerSkinSettingsArray;
#nullable enable
        
        protected override PlayerCustomizer Create()
        {
            return new PlayerCustomizer(
                _gameSaver.GetHeldItem(), _spriteRenderer,
                _playerSkinSettingsArray.Select(playerSkinSettings => playerSkinSettings.PlayerSkinInfo).ToArray()
                );
        }
    }
}