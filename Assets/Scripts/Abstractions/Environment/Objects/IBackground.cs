using GachiBird.Environment.Colliders;

namespace GachiBird.Environment.Objects
{
    public interface IBackground
    {
        ICollider2DListener BackgroundPassCollider2DListener { get; }
    }
}