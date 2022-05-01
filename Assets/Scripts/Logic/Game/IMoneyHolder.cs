using System;

namespace GachiBird.Game
{
    public interface IMoneyHolder
    {
        int Money { get; set; }

        event Action? OnMoneyChanged;
    }
}