using System;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public interface IBooster
    {
        ICollider2DListener CheckpointListener { get; }
        ICollider2DListener BoosterPickUpListener { get; }

        event Action<GameObject, IBooster, BoosterInfo>? OnPickUp;

        void Initialize(BoosterInfo boosterInfo);
    }
}