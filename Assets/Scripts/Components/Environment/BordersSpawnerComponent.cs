using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BordersSpawnerComponent : AbstractComponent<BordersSpawner>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _bordersPool;
        [SerializeField] private float _gap;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Transform _player;
#nullable enable
        
        protected override BordersSpawner Create()
        {
            return new BordersSpawner(_bordersPool.GetHeldItem(), _gap, _playerOffset, _player);
        }
    }
}