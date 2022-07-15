using System;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class Booster : IBooster
    {
        public ICollider2DListener CheckpointListener { get; }
        public ICollider2DListener BoosterPickUpListener { get; }
        public event Action<GameObject, IBooster, BoosterInfo>? OnPickUp;

        private readonly SpriteRenderer _spriteRenderer;
        private readonly Vector2 _boosterSize;
        
        private BoosterInfo _boosterInfo;

        public Booster(
            ICollider2DListener checkpointListener, ICollider2DListener boosterListener, SpriteRenderer spriteRenderer,
            Vector2 boosterSize)
        {
            CheckpointListener = checkpointListener;
            BoosterPickUpListener = boosterListener;
            _spriteRenderer = spriteRenderer;
            _boosterSize = boosterSize;

            BoosterPickUpListener.OnTrigger += (_, __) => OnPickUp?.Invoke(
                spriteRenderer.gameObject,
                this,
                _boosterInfo
            );
        }

        public void Initialize(BoosterInfo boosterInfo)
        {
            _boosterInfo = boosterInfo;
            _spriteRenderer.sprite = boosterInfo.Sprite;

            Vector2 spriteSize = _spriteRenderer.sprite.rect.size;
            Vector2 spriteRendererSize;
            if (spriteSize.x > spriteSize.y)
            {
                float spriteRendererWidth = _boosterSize.x;
                float ratio = spriteSize.y / spriteSize.x;
                float spriteRendererHeight = spriteRendererWidth * ratio;

                spriteRendererSize = new Vector2(spriteRendererWidth, spriteRendererHeight);
            }
            else if (spriteSize.x < spriteSize.y)
            {
                float spriteRendererHeight = _boosterSize.y;
                float ratio = spriteSize.x / spriteSize.y;
                float spriteRendererWidth = spriteRendererHeight * ratio;

                spriteRendererSize = new Vector2(spriteRendererWidth, spriteRendererHeight);
            }
            else
            {
                spriteRendererSize = new Vector2(_boosterSize.x, _boosterSize.y);
            }
            
            _spriteRenderer.size = spriteRendererSize / 100;
        }
    }
}
