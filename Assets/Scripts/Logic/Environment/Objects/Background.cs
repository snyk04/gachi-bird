using GachiBird.Environment.Colliders;

namespace GachiBird.Environment.Objects
{
    public sealed class Background : IBackground
    {
        public ICollider2DListener BackgroundPassCollider2DListener { get; }

        public Background(ICollider2DListener backgroundPassCollider2DListener)
        {
            BackgroundPassCollider2DListener = backgroundPassCollider2DListener;
        }
    }
}