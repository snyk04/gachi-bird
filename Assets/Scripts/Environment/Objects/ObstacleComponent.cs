#nullable enable

using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class ObstacleComponent : MonoBehaviour
    {
#nullable disable
        [SerializeField] private Collider2DListener _checkpointCollider2DListener;
#nullable enable
        
        public Collider2DListener CheckpointCollider2DListener => _checkpointCollider2DListener;
    }
}
