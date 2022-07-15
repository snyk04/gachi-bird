using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BoosterComponent : AbstractComponent<Booster>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private Collider2DListener _checkpointCollider2DListener;
        [SerializeField] private Collider2DListener _boosterPickedUpCollider2DListener;
        
        [Header("Objects")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Settings")] 
        [SerializeField] private Vector2 _boosterSize;
#nullable enable

        protected override Booster Create()
        {
            return new Booster(_checkpointCollider2DListener, _boosterPickedUpCollider2DListener, 
                _spriteRenderer, _boosterSize);
        }
    }
}
