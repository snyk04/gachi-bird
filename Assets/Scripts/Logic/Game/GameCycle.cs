﻿#nullable enable

using System;
using GachiBird.Environment.Colliders;
using GachiBird.Input;
using GachiBird.PlayerLogic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GachiBird.Game
{
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