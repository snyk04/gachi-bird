using GachiBird.Game;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerPreGameLevitator
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _defaultGravityScale;

        public PlayerPreGameLevitator(IGameCycle gameCycle, Rigidbody2D rigidbody, float defaultGravityScale)
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
