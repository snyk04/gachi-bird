#nullable enable

using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GachiBird.Game
{
    public sealed class GameCycleComponent : AbstractComponent<GameCycle>
    {
#nullable disable
        [SerializeField] private PlayerBordersTriggerComponent _playerBordersTrigger;
        [SerializeField] private Collider2DListener _playerColliderListener;
#nullable enable
        
        protected override GameCycle Create()
        {
            return new GameCycle(_playerBordersTrigger, _playerColliderListener);
        }
    }
    
    public sealed class GameCycle
    {
        private readonly InputAction _playerJumpAction;
        
        public event Action? OnGameStart;
        public event Action? OnGameEnd;
        
        public GameCycle(PlayerBordersTriggerComponent playerBordersTrigger, Collider2DListener playerColliderListener)
        {
            _playerJumpAction = new Controls().Player.Jump;
            
            _playerJumpAction.performed += StartGame;
            _playerJumpAction.Enable();
            
            playerBordersTrigger.HeldItem.OnPlayerOutOfBounds += EndGame;
            playerColliderListener.OnCollide += (_, __) => EndGame();
        }

        private void StartGame(InputAction.CallbackContext context)
        {
            _playerJumpAction.performed -= StartGame;
            _playerJumpAction.Disable();
            
            OnGameStart?.Invoke();
        }
        
        private void EndGame()
        {
            OnGameEnd?.Invoke();
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
