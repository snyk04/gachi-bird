using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BordersComponent : AbstractComponent<Borders, IBorders>
    {
#nullable disable
        [SerializeField] private Collider2DListener _backgroundPassCollider2DListener;
        [SerializeField] private Collider2DListener _ceilingCollider2DListener;
        [SerializeField] private Collider2DListener _floorCollider2DListener;
#nullable enable
        
        protected override Borders Create()
        {
            return new Borders(_backgroundPassCollider2DListener,
                _ceilingCollider2DListener, _floorCollider2DListener);
        }
    }
}