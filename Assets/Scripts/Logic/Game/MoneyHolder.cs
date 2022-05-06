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

        public MoneyHolder(IScoreHolder scoreHolder, IGameSaver gameSaver)
        {
            // TODO : Make amount of money per point configurable or taken from IScoreHolder
            Money = gameSaver.LoadAmountOfMoney();
            scoreHolder.OnScoreChanged += () => Money += 1;
        }
    }
}