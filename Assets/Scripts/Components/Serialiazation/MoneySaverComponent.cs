using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class MoneySaverComponent : AbstractComponent<MoneySaver>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IMoneyHolder>> _moneyHolder;
#nullable enable

        protected override MoneySaver Create()
        {
            return new MoneySaver(_gameSaver.GetHeldItem(), _moneyHolder.GetHeldItem());
        }
    }
}