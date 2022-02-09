#nullable enable

using System;
using UnityEngine;

namespace GachiBird.Environment.Colliders
{
    public interface ICollider2DListener
    {
        event Action<Collider2D, ICollider2DListener>? OnTrigger;
        event Action<Collision2D, ICollider2DListener>? OnCollide;
    }
}
