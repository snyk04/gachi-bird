using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class StatusOfSkinsFillerComponent : AbstractComponent<StatusOfSkinsFiller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaverLoader>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;
#nullable enable
        
        protected override StatusOfSkinsFiller Create()
        {
            return new StatusOfSkinsFiller(_gameSaver.GetHeldItem(), _playerCustomizer.GetHeldItem());
        }
    }
}