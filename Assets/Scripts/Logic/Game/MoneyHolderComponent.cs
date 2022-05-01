using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Game
{
    public class MoneyHolderComponent : AbstractComponent<MoneyHolder>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
#nullable enable
        
        protected override MoneyHolder Create()
        {
            return new MoneyHolder(_scoreHolder.GetHeldItem());
        }
    }
}