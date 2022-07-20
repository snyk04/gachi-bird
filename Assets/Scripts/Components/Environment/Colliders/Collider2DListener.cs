using System;
using UnityEngine;

namespace GachiBird.Environment.Colliders
{
    public sealed class Collider2DListener : MonoBehaviour, ICollider2DListener
    {
        private bool _isActive;
        
        public Collider2D[] Colliders => new[] { GetComponent<Collider2D>() };

        public event Action<Collider2D, ICollider2DListener>? OnTrigger;
        public event Action<Collision2D, ICollider2DListener>? OnCollide;

        private void Awake()
        {
            _isActive = true;
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isActive)
            {
                OnTrigger?.Invoke(other, this);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isActive)
            {
                OnCollide?.Invoke(collision, this);
            }
        }
    }
}