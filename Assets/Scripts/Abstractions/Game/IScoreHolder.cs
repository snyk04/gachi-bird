#nullable enable

using System;

namespace GachiBird.UserWindows
{
    public interface IScoreHolder
    {
        public int Score { get; }
        public int BestScore { get; }

        public event Action? OnScoreChanged;
        public event Action? OnBestScoreChanged;

        public void Add(int points);
    }
}
