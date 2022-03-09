using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserInterface
{
    public class UserInterfaceCycleComponent : AbstractComponent<UserInterfaceCycle>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
#nullable enable

        protected override UserInterfaceCycle Create()
        {
            return new UserInterfaceCycle(_gameCycle.GetHeldItem(), _gameSaver.GetHeldItem());
        }
    }
}