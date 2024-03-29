﻿using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerBordersTriggerComponent : AbstractComponent<PlayerBordersTrigger>
    {
#nullable disable
        [SerializeField] private Transform _player;
        [SerializeField] private Range<float> _heightBounds;
#nullable enable

        protected override PlayerBordersTrigger Create()
        {
            var trigger = new PlayerBordersTrigger(_player, _heightBounds);
            trigger.Start();

            return trigger;
        }

        private void OnDrawGizmosSelected()
        {
            if (!_heightBounds.IsBounded)
            {
                return;
            }

            Gizmos.color = Color.cyan;
            Vector3 center = _heightBounds.Average() * Vector3.up;
            const float depth = 10.0f;
            const float width = 100_000.0f;
            Gizmos.DrawWireCube(center, new Vector3(width, _heightBounds.Difference(), depth));
        }
    }
}
