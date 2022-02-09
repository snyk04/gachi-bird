#nullable enable

using System;

namespace GachiBird.Game
{
    public interface IGameCycle
    {
        public event Action? OnGameStart;
        public event Action? OnGameEnd;

        public void RestartGame();
    }
}
