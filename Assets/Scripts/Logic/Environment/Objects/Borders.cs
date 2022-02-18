using GachiBird.Environment.Colliders;

namespace GachiBird.Environment
{
    public sealed class Borders : IBorders
    {
        public ICollider2DListener BordersPassedCollider2DListener { get; }
        public ICollider2DListener CeilingCollider2DListener { get; }
        public ICollider2DListener FloorCollider2DListener { get; }

        public Borders(ICollider2DListener bordersPassedCollider2DListener, 
            ICollider2DListener ceilingCollider2DListener, ICollider2DListener floorCollider2DListener)
        {
            BordersPassedCollider2DListener = bordersPassedCollider2DListener;
            CeilingCollider2DListener = ceilingCollider2DListener;
            FloorCollider2DListener = floorCollider2DListener;
        }
    }
}