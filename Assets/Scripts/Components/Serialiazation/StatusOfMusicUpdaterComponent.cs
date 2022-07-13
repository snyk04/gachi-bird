using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Flex;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class StatusOfMusicUpdaterComponent : AbstractComponent<StatusOfMusicUpdater>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaverLoader>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
#nullable enable
        
        protected override StatusOfMusicUpdater Create()
        {
            return new StatusOfMusicUpdater(_gameSaver.GetHeldItem(), _flexModeHandler.GetHeldItem());
        }
    }
}