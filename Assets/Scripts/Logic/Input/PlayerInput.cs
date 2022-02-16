using System;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine.InputSystem;

namespace GachiBird.Input
{
    public sealed class PlayerInput : IDisposable
    {
        private readonly IJumpable _player;
        private readonly InputAction _jumpAction = new Controls().Player.Jump;

        public PlayerInput(IGameCycle gameCycle, IJumpable player)
        {
            _player = player;
            
            _jumpAction.performed += Jump;
            _jumpAction.Enable();
            
            gameCycle.OnGameEnd += Dispose;
        }
        
        public void Dispose()
        {
            _jumpAction.Disable();
            _jumpAction.performed -= Jump;
        }
        
        private void Jump(InputAction.CallbackContext context) => _player.Jump();
    }
}
