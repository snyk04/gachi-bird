#nullable enable

using AreYouFruits.Common;
using GachiBird.Environment.Objects;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Environment.Pooling
{
    public sealed class GameObjectPoolComponent : AbstractComponent<GameObjectPool>
    {
#nullable disable
        [SerializeField] private int _amountOfObjectsInPool;
        [SerializeField] private GameObject _prefab;
#nullable enable

        protected override GameObjectPool Create()
        {
            var item = new GameObjectPool(_amountOfObjectsInPool, _prefab, transform);
            item.Start();
            
            return item;
        }
    }
    
    public class GameObjectPool : InitOnStartPool<GameObject>
    {
        protected readonly int Count;
        protected readonly GameObject? Prefab;
        protected readonly Transform? Parent;
        protected readonly string? DefaultName;

        public GameObjectPool(
            int count, GameObject? prefab = null, Transform? parent = null, string? defaultName = null
        )
        {
            Count = count;
            Prefab = prefab;
            Parent = parent;
            DefaultName = defaultName;
        }

        public void Start() => base.Start(Count);

        protected override GameObject Create()
        {
            GameObject gameObject = GameObjectHelper.Create(Prefab, DefaultName, Parent);
            HandleDeactivated(gameObject);

            return gameObject;
        }

        protected override void HandleActivated(GameObject element) => element.SetActive(true);
        protected override void HandleDeactivated(GameObject element) => element.SetActive(false);
    }
}
