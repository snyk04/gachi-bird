#nullable enable

using System;

namespace GachiBird.Environment
{
    public interface IObstacleSpawner
    {
        event Action? OnObstaclePassed;
    }
}
