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
            return new GameObjectPool(_amountOfObjectsInPool, _prefab, transform);
        }

        private void Start() => ((GameObjectPool)HeldItem).Start();
    }
}
