using System;

namespace GachiBird.Environment
{
    public interface IBoosterSpawner
    {
        public event Action? OnBoosterCollected;
    }
}