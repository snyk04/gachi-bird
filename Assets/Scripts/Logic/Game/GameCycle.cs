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
        public event Action? OnGameStart;
        public event Action? OnGameEnd;
        public event Action? OnGameRestart;

        public bool IsPlaying { get; private set; }
        
        private readonly int _gameSceneId;

        public GameCycle(int gameSceneId)
        {
            _gameSceneId = gameSceneId;
        }

        public void StartGame()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
                OnGameStart?.Invoke();
            }
        }

        public void EndGame()
        {
            if (IsPlaying)
            {
                IsPlaying = false;
                OnGameEnd?.Invoke();
            }
        }

        public void RestartGame()
        {
            OnGameRestart?.Invoke();
            SceneManager.LoadScene(_gameSceneId);
        }
    }
}
