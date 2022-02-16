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
        
        event Action<GameObject, IBooster, BoosterInfo> PickedUp;

        void Initialize(BoosterInfo boosterInfo);
    }
}