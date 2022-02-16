using GachiBird.Environment.Colliders;

namespace GachiBird.Environment.Objects
{
    public interface IBooster
    {
        ICollider2DListener CheckpointCollider2DListener { get; }

        void Initialize(BoosterInfo boosterSettings);
    }
}