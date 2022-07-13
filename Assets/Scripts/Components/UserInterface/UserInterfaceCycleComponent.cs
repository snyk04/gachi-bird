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
#nullable enable

        protected void Start()
        {
            HeldItem.Start();
        }
        
        protected override UserInterfaceCycle Create()
        {
            return new UserInterfaceCycle(_gameCycle.GetHeldItem());
        }
    }
}