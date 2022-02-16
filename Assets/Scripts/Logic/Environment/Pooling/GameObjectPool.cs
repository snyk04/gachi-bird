using System;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Environment.Pooling
{
    public sealed class GameObjectPool : InitOnTheWayPool<GameObject>
    {
        private readonly GameObject? _prefab;
        private readonly Transform? _parent;
        private readonly string? _defaultName;
        
        protected override int MaxCount { get; }

        public GameObjectPool(
            int count, GameObject? prefab = null, Transform? parent = null, string? defaultName = null
        )
        {
            MaxCount = count;
            _prefab = prefab;
            _parent = parent;
            _defaultName = defaultName;
        }

        protected override GameObject Create()
        {
            GameObject gameObject = GameObjectHelper.Create(_prefab, _defaultName, _parent);
            HandleDeactivated(gameObject);
            
            return gameObject;
        }

        protected override void HandleActivated(GameObject element) => element.SetActive(true);
        protected override void HandleDeactivated(GameObject element) => element.SetActive(false);
    }
}
