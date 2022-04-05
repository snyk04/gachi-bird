using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BoosterComponent : AbstractComponent<Booster>
    {
#nullable disable
        [SerializeField] private Collider2DListener _checkpointCollider2DListener;
        [SerializeField] private Collider2DListener _boosterPickedUpCollider2DListener;
        [SerializeField] private SpriteRenderer _spriteRenderer;
#nullable enable

        protected override Booster Create()
        {
            return new Booster(_checkpointCollider2DListener, _boosterPickedUpCollider2DListener, _spriteRenderer);
        }
    }
}
