using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class CurrentSkinIdSaverComponent : AbstractComponent<CurrentSkinIdSaver>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaverLoader>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomization;
#nullable enable
        
        protected override CurrentSkinIdSaver Create()
        {
            return new CurrentSkinIdSaver(_gameSaver.GetHeldItem(), _playerCustomization.GetHeldItem());
        }
    }
}