using System;
using GachiBird.Environment.Objects;

namespace GachiBird.Environment
{
    public interface IBoosterSpawner
    {
        event Action<IBooster>? OnBoosterSpawned;
        BoosterInfo[] BoosterInfos { get; }
    }
}