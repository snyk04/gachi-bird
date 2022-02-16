using AreYouFruits.Common.ComponentGeneration;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game
{
    public sealed class PlayerOutOfBoundsGameEnderComponent : AbstractComponent<PlayerOutOfBoundsGameEnder>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IPlayerBordersTrigger> _playerBordersTrigger;
#nullable enable
        
        protected override PlayerOutOfBoundsGameEnder Create()
        {
            return new PlayerOutOfBoundsGameEnder(_gameCycle.HeldItem, _playerBordersTrigger.HeldItem);
        }
    }
}
