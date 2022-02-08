#nullable enable

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
#nullable disable
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private AbstractComponent<IPlayer> _player;
#nullable enable
        
        protected override PlayerInput Create() => new PlayerInput(_gameCycle.HeldItem, _player.HeldItem);
    }

    public class PlayerInput : IDisposable
    {
        private readonly IPlayer _player;
        private readonly InputAction _jumpAction = new Controls().Player.Jump;

        public PlayerInput(IGameCycle gameCycle, IPlayer player)
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
            _player.Jump();
        }
    }
}
