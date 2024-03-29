﻿using System;

namespace GachiBird.Game
{
    public interface IGameCycle
    {
        public event Action? OnGameStart;
        public event Action? OnGameEnd;
        public event Action? OnGameRestart;
        public bool IsPlaying { get; }

        public void StartGame();
        public void EndGame();
        public void RestartGame();
    }
}
