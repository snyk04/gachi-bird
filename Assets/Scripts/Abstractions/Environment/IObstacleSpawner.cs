using System;

namespace GachiBird.Environment
{
    public interface IObstacleSpawner
    {
        float Gap { get; }
        
        event Action? OnObstaclePassed;
    }
}
