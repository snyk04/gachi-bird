#nullable enable

using System.Linq;
using AreYouFruits.Common;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment.Objects;
using GachiBird.Environment.Pooling;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class BoosterSpawnerComponent : AbstractComponent<IBoosterSpawner>
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IPool<GameObject>> _gameObjectPool;
        [SerializeField] private AbstractComponent<IObstacleSpawner> _obstacleSpawner;
        [SerializeField] private BoosterSettings[] _boosterSettingsArray;
        [SerializeField] private Range<int> _gapRange;
        [SerializeField] private Vector3 _playerOffset;
        [SerializeField] private Range<float> _widthRange;
        [SerializeField] private Range<float> _heightRange;
        [SerializeField] private Transform _player;
#nullable enable

        protected override IBoosterSpawner Create()
        {
            return new BoosterSpawner(
                _gameCycle.HeldItem,
                _gameObjectPool.HeldItem,
                _obstacleSpawner.HeldItem,
                _boosterSettingsArray.Select(boosterSettings => boosterSettings.BoosterInfo).ToArray(),
                _gapRange,
                _playerOffset,
                _widthRange,
                _heightRange,
                _player);
        }
    }
}