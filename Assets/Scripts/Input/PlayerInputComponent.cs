using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace GachiBird.Input
{
    public class PlayerInputComponent : DestroyableAbstractComponent<PlayerInput>
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private PlayerComponent _player;

        protected override PlayerInput Create() => new PlayerInput(_gameCycle, _player);
    }

    public class PlayerInput : IDisposable
    {
        private readonly PlayerComponent _player;
        private readonly InputAction _jumpAction = new Controls().Player.Jump;
        
        public PlayerInput(GameCycle gameCycle, PlayerComponent player)
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
        
        private void Jump(CallbackContext context)
        {
            _player.HeldItem.Jump();
        }
    }
}
