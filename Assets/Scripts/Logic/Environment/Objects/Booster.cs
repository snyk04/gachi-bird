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
        private BoosterInfo _boosterInfo;

        public Booster(
            ICollider2DListener checkpointListener, ICollider2DListener boosterListener,
            SpriteRenderer spriteRenderer
        )
        {
            CheckpointListener = checkpointListener;
            BoosterPickUpListener = boosterListener;
            _spriteRenderer = spriteRenderer;

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
        }
    }
}
