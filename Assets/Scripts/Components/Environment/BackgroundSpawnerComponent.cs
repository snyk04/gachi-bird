using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BackgroundSpawnerComponent : AbstractComponent<BackgroundSpawner>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _backgroundPool;
        [SerializeField] private float _gap;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Transform _player;
#nullable enable
        
        protected override BackgroundSpawner Create()
        {
            return new BackgroundSpawner(_backgroundPool.GetHeldItem(), _gap, _playerOffset,
                _player);
        }
    }
}