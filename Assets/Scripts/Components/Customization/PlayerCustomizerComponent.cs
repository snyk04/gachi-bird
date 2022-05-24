using System.Linq;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.Serialization;
using GachiBird.UserInterface.Shop;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizerComponent : AbstractComponent<PlayerCustomizer>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IMoneyHolder>> _moneyHolder;
        [SerializeField] private SerializedInterface<IComponent<IApprover>> _approver;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private PlayerSkinSettings[] _playerSkinSettingsArray;
#nullable enable
        
        protected override PlayerCustomizer Create()
        {
            return new PlayerCustomizer(
                _gameSaver.GetHeldItem(),
                _moneyHolder.GetHeldItem(),
                _approver.GetHeldItem(),
                _spriteRenderer,
                _playerSkinSettingsArray.Select(settings => settings.PlayerSkinInfo).ToArray()
                );
        }
    }
}