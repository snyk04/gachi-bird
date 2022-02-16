#nullable enable

using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BoosterComponent : AbstractComponent<IBooster>
    {
#nullable disable
        [SerializeField] private Collider2DListener _checkpointCollider2DListener;
        [SerializeField] private Collider2DListener _boosterPickedUpCollider2DListener;
#nullable enable
        
        protected override IBooster Create()
        {
            return new Booster(_checkpointCollider2DListener, _boosterPickedUpCollider2DListener,
                GetComponent<SpriteRenderer>());
        }
    }
}