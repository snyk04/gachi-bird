using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public class PlayerPreGameLevitatorComponent : AbstractComponent<PlayerPreGameLevitator>
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _defaultGravityScale;

        protected override PlayerPreGameLevitator Create()
        {
            var item = new PlayerPreGameLevitator(_gameCycle, _rigidbody, _defaultGravityScale);

            item.Start();

            return item;
        }
    }

    public class PlayerPreGameLevitator
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _defaultGravityScale;

        public PlayerPreGameLevitator(GameCycle gameCycle, Rigidbody2D rigidbody, float defaultGravityScale)
        {
            gameCycle.OnGameStart += HandleGameStart;
            _rigidbody = rigidbody;
            _defaultGravityScale = defaultGravityScale;
        }

        public void Start()
        {
            _rigidbody.gravityScale = 0.0f;
        }

        private void HandleGameStart()
        {
            _rigidbody.gravityScale = _defaultGravityScale;
        }
    }
}
