using System;
using GachiBird.Serialization;

namespace GachiBird.Game
{
    public sealed class MoneyHolder : IMoneyHolder
    {
        private int _money;

        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                OnMoneyChanged?.Invoke();
            }
        }

        public event Action? OnMoneyChanged;

        public MoneyHolder(IScoreHolder scoreHolder, IGameLoader gameLoader)
        {
            // TODO : Make amount of money per point configurable or taken from IScoreHolder
            const int moneyPerObstacleAmount = 1;
            Money = gameLoader.MoneyAmount;
            scoreHolder.OnScoreChanged += () => Money += moneyPerObstacleAmount;
        }
    }
}