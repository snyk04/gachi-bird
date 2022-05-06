using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.Game
{
    public class MoneyHolderComponent : AbstractComponent<MoneyHolder>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
#nullable enable
        
        protected override MoneyHolder Create()
        {
            return new MoneyHolder(_scoreHolder.GetHeldItem(), _gameSaver.GetHeldItem());
        }
    }
}