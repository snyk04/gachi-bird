using AreYouFruits.Common.ComponentGeneration;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class PlayerOutOfBoundsGameEnderComponent : AbstractComponent<PlayerOutOfBoundsGameEnder>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IPlayerBordersTrigger>> _playerBordersTrigger;
#nullable enable
        
        protected override PlayerOutOfBoundsGameEnder Create()
        {
            return new PlayerOutOfBoundsGameEnder(_gameCycle.GetHeldItem(), _playerBordersTrigger.GetHeldItem());
        }
    }
}
