#nullable enable

using System;

namespace GachiBird.Game
{
    public interface IScoreHolder
    {
        public int Score { get; }
        public int HighScore { get; }

        public event Action? OnScoreChanged;
        public event Action? OnHighScoreChanged;

        public void Add(int points);
    }
}
