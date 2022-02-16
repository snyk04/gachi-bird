using System;
using System.Collections.Generic;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class ObstacleComponent : MonoBehaviour, IObstacle
    {
#nullable disable
        [SerializeField] private Collider2DListener _checkpointCollider2DListener;
        [SerializeField] private Collider2DListener _obstacleTopCollider2DListener;
        [SerializeField] private Collider2DListener _obstacleBottomCollider2DListener;
        
        public ICollider2DListener ObstacleCollider2DListener { get; private set; }
#nullable enable

        public ICollider2DListener CheckpointCollider2DListener => _checkpointCollider2DListener;

        private void Awake()
        {
            ObstacleCollider2DListener = new CommonCollider2DListener(
                _obstacleTopCollider2DListener,
                _obstacleBottomCollider2DListener
            );
        }
        
        // todo: search for more elegant solution
        private class CommonCollider2DListener : ICollider2DListener
        {
            public event Action<Collider2D, ICollider2DListener>? OnTrigger;
            public event Action<Collision2D, ICollider2DListener>? OnCollide;

            public CommonCollider2DListener(params ICollider2DListener[] listeners) 
                : this((IEnumerable<ICollider2DListener>)listeners) { }

            public CommonCollider2DListener(IEnumerable<ICollider2DListener> listeners)
            {
                foreach (ICollider2DListener listener in listeners)
                {
                    listener.OnTrigger += (c, l) => OnTrigger?.Invoke(c, l);
                    listener.OnCollide += (c, l) => OnCollide?.Invoke(c, l);
                }
            }
        }
    }
}
