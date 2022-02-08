using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class ObstacleComponent : MonoBehaviour
    {
        [field: SerializeField] public Collider2DListener CheckpointCollider2DListener;
    }
}
