using GachiBird.Environment.Colliders;

namespace GachiBird.Environment.Objects
{
    public interface IObstacle
    {
        ICollider2DListener CheckpointCollider2DListener { get; }
        ICollider2DListener ObstacleCollider2DListener { get; }
    }
}
