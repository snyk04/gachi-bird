﻿using System;
using GachiBird.Environment.Colliders;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    public sealed class Booster : IBooster
    {
        public ICollider2DListener CheckpointCollider2DListener { get; }
        public ICollider2DListener BoosterPickedUpCollider2DListener { get; }
        public Action<GameObject, IBooster, BoosterInfo>? PickedUp { get; set; }

        private readonly SpriteRenderer _spriteRenderer;
        private BoosterInfo _boosterInfo;

        public Booster(
            ICollider2DListener checkpointCollider2DListener, ICollider2DListener boosterCollider2DListener,
            SpriteRenderer spriteRenderer
        )
        {
            CheckpointCollider2DListener = checkpointCollider2DListener;
            BoosterPickedUpCollider2DListener = boosterCollider2DListener;
            _spriteRenderer = spriteRenderer;

            BoosterPickedUpCollider2DListener.OnTrigger += (_, __) => PickedUp?.Invoke(
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
