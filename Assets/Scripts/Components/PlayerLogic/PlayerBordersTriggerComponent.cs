#nullable enable

using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerBordersTriggerComponent 
        : DestroyableAbstractComponent<IPlayerBordersTrigger, PlayerBordersTrigger>
    {
#nullable disable
        [SerializeField] private Transform _player;
        [SerializeField] private Range<float> _heightBounds;
#nullable enable
        
        protected override IPlayerBordersTrigger Create()
        {
            var trigger = new PlayerBordersTrigger(_player, _heightBounds);
            trigger.Start();
            
            return trigger;
        }

        private void OnDrawGizmosSelected()
        {
            if (_heightBounds.IsBounded)
            {
                Gizmos.color = Color.cyan;
                Vector3 center = (_heightBounds.Min + _heightBounds.Max) / 2.0f * Vector3.up;
                const float depth = 10.0f;
                const float width = 100_000.0f;
                Gizmos.DrawWireCube(center, new Vector3(width, _heightBounds.Max - _heightBounds.Min, depth));
            }
        }
    }
}
