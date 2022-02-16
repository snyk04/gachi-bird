using System;
using UnityEngine;

namespace GachiBird.Environment.Colliders
{
    public sealed class Collider2DListener : MonoBehaviour, ICollider2DListener
    {
        public Collider2D[] Colliders => new[] { GetComponent<Collider2D>() };

        public event Action<Collider2D, ICollider2DListener>? OnTrigger;
        public event Action<Collision2D, ICollider2DListener>? OnCollide;

        private void OnTriggerEnter2D(Collider2D other) => OnTrigger?.Invoke(other, this);

        private void OnCollisionEnter2D(Collision2D collision) => OnCollide?.Invoke(collision, this);
    }
}