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
    public sealed class GameCycleComponent : AbstractComponent<IGameCycle>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IPlayerBordersTrigger> _playerBordersTrigger;
        [SerializeField] private Collider2DListener _playerColliderListener;
#nullable enable
        
        protected override IGameCycle Create()
        {
            return new GameCycle(_playerBordersTrigger.HeldItem, _playerColliderListener);
        }
    }

    public interface IGameCycle
    {
        public event Action? OnGameStart;
        public event Action? OnGameEnd;

        public void RestartGame();
    }
    
    public sealed class GameCycle : IGameCycle
    {
        private readonly InputAction _playerJumpAction;
        
        public event Action? OnGameStart;
        public event Action? OnGameEnd;
        
        public GameCycle(IPlayerBordersTrigger playerBordersTrigger, ICollider2DListener playerColliderListener)
        {
            _playerJumpAction = new Controls().Player.Jump;
            
            _playerJumpAction.performed += StartGame;
            _playerJumpAction.Enable();
            
            playerBordersTrigger.OnPlayerOutOfBounds += EndGame;
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
