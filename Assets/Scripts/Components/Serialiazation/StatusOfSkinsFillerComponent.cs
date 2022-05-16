using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using UnityEngine;

namespace GachiBird.Serialization
{
    public class StatusOfSkinsFillerComponent : AbstractComponent<StatusOfSkinsFiller>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IBoosterSpawner>> _boosterSpawner;
#nullable enable
        
        protected override StatusOfSkinsFiller Create()
        {
            return new StatusOfSkinsFiller(_gameSaver.GetHeldItem(), _boosterSpawner.GetHeldItem());
        }
    }
}