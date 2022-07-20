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
            private bool _isActive;
            
            public Collider2D[] Colliders { get; }
            
            public event Action<Collider2D, ICollider2DListener>? OnTrigger;
            public event Action<Collision2D, ICollider2DListener>? OnCollide;

            public CommonCollider2DListener(params ICollider2DListener[] listeners)
                : this((IEnumerable<ICollider2DListener>)listeners) { }

            public CommonCollider2DListener(IEnumerable<ICollider2DListener> listeners)
            {
                _isActive = true;
                
                var colliders = new List<Collider2D>();
                
                foreach (ICollider2DListener listener in listeners)
                {
                    listener.OnTrigger += HandleTrigger;
                    listener.OnCollide += HandleCollide;

                    colliders.AddRange(listener.Colliders);
                }

                Colliders = colliders.ToArray();
            }

            public void SetActive(bool isActive)
            {
                _isActive = isActive;
            }

            private void HandleTrigger(Collider2D c, ICollider2DListener l)
            {
                if (_isActive)
                {
                    OnTrigger?.Invoke(c, l);
                }
            }
            private void HandleCollide(Collision2D c, ICollider2DListener l)
            {
                if (_isActive)
                {
                    OnCollide?.Invoke(c, l);
                }
            }
        }
    }
}
