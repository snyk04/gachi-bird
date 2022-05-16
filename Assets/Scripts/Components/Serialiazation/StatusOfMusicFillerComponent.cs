using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class StatusOfMusicFillerComponent : AbstractComponent<StatusOfMusicFiller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IBoosterSpawner>> _boosterSpawner;
#nullable enable
        
        protected override StatusOfMusicFiller Create()
        {
            return new StatusOfMusicFiller(_gameSaver.GetHeldItem(), _boosterSpawner.GetHeldItem());
        }
    }
}