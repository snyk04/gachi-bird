using System;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public interface IBooster
    {
        // TODO : Rename?
        ICollider2DListener CheckpointCollider2DListener { get; }
        ICollider2DListener BoosterPickedUpCollider2DListener { get; }

        Action<GameObject, IBooster, BoosterInfo>? PickedUp { get; set; }

        void Initialize(BoosterInfo boosterInfo);
    }
}