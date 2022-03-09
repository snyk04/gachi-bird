using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class BackgroundComponent : AbstractComponent<Background>
    {
#nullable disable
        [SerializeField] private Collider2DListener _backgroundPassCollider2DListener;
#nullable enable
        
        protected override Background Create()
        {
            return new Background(_backgroundPassCollider2DListener);
        }
    }
}