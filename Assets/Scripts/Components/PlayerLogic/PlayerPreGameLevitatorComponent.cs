using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerPreGameLevitatorComponent : AbstractComponent<PlayerPreGameLevitator>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _defaultGravityScale;
#nullable enable
        
        protected override PlayerPreGameLevitator Create()
        {
            var item = new PlayerPreGameLevitator(_gameCycle.GetHeldItem(), _rigidbody, _defaultGravityScale);

            item.Start();

            return item;
        }
    }
}
