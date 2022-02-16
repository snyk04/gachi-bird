using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class Booster : IBooster
    {
        public ICollider2DListener CheckpointCollider2DListener { get; }

        private readonly SpriteRenderer _spriteRenderer;

        public Booster(ICollider2DListener checkpointCollider2DListener, SpriteRenderer spriteRenderer)
        {
            CheckpointCollider2DListener = checkpointCollider2DListener;
            _spriteRenderer = spriteRenderer;
        }
        
        public void Initialize(BoosterInfo boosterSettings)
        {
            _spriteRenderer.sprite = boosterSettings.Sprite;
        } 
    }
}