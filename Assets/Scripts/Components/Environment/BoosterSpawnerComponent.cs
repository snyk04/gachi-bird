using System.Linq;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BoosterSpawnerComponent : AbstractComponent<BoosterSpawner>
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IPool<GameObject>>> _gameObjectPool;
        [SerializeField] private SerializedInterface<IComponent<IObstacleSpawner>> _obstacleSpawner;
        [SerializeField] private BoosterSettings[] _boosterSettingsArray;
        [SerializeField] private Range<int> _gapRange;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Range<float> _widthRange;
        [SerializeField] private Range<float> _heightRange;
        [SerializeField] private Transform _player;
#nullable enable

        protected override BoosterSpawner Create()
        {
            return new BoosterSpawner(
                _gameCycle.GetHeldItem(),
                _gameObjectPool.GetHeldItem(),
                _obstacleSpawner.GetHeldItem(),
                _boosterSettingsArray.Select(boosterSettings => boosterSettings.BoosterInfo).ToArray(),
                _gapRange,
                _playerOffset,
                _widthRange,
                _heightRange,
                _player
            );
        }
    }
}
