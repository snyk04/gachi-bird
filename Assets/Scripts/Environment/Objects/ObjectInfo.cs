using System;
using UnityEngine;

namespace Environment.Objects
{
    [Serializable] 
    public struct ObjectInfo
    {
        #region Settings

        [SerializeField] private ObjectType _objectType;
        
        [Header("Pooling")]
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _amountOfObjectsInPool;
        
        [Header("Spawning")]
        [SerializeField] private float _distanceBetweenObjects;
        [SerializeField] private int _amountOfObjectsToSpawnAtStart;
        [SerializeField] private Vector3 _spawnOffsetFromStart;
        [SerializeField] private Vector2 _allowedErrorRangeForAxisX;
        [SerializeField] private Vector2 _allowedErrorRangeForAxisY;

        public ObjectType ObjectType => _objectType;
        public GameObject Prefab => _prefab;
        public int AmountOfObjectsInPool => _amountOfObjectsInPool;
        public float DistanceBetweenObjects => _distanceBetweenObjects;
        public int AmountOfObjectsToSpawnAtStart => _amountOfObjectsToSpawnAtStart;
        public Vector3 SpawnOffsetFromStart => _spawnOffsetFromStart;
        public Vector2 AllowedErrorRangeForAxisX => _allowedErrorRangeForAxisX;
        public Vector2 AllowedErrorRangeForAxisY => _allowedErrorRangeForAxisY;

        #endregion

        public ObjectInfo(ObjectType objectType)
        {
            _objectType = objectType;
            _prefab = default;
            _amountOfObjectsInPool = default;
            _distanceBetweenObjects = default;
            _amountOfObjectsToSpawnAtStart = default;
            _spawnOffsetFromStart = default;
            _allowedErrorRangeForAxisX = default;
            _allowedErrorRangeForAxisY = default;
        }
    }
}
