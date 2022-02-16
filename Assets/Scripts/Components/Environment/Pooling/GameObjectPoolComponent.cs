using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Environment.Pooling
{
    public sealed class GameObjectPoolComponent : AbstractComponent<IPool<GameObject>>
    {
#nullable disable
        [SerializeField] private int _amountOfObjectsInPool;
        [SerializeField] private GameObject _prefab;
#nullable enable

        protected override IPool<GameObject> Create()
        {
            var item = new GameObjectPool(_amountOfObjectsInPool, _prefab, transform);
            item.Start();
            
            return item;
        }
    }
}
