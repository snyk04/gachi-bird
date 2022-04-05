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
            return new GameObjectPool(_amountOfObjectsInPool, _prefab, transform);
        }

        private void Start() => ((GameObjectPool)HeldItem).Start();
    }
}
