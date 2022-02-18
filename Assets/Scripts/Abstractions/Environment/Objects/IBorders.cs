using GachiBird.Environment.Colliders;

namespace GachiBird.Environment
{
    public interface IBorders
    {
        ICollider2DListener BordersPassedCollider2DListener { get; }
        ICollider2DListener CeilingCollider2DListener { get; }
        ICollider2DListener FloorCollider2DListener { get; }
    }
}