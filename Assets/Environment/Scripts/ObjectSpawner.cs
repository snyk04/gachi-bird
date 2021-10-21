using System;
using Environment.Objects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment
{
    public sealed class ObjectSpawner : MonoBehaviour
    {
        public static ObjectSpawner Instance { get; private set; }
        private void CreateSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        #region References

        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ObjectPooling _objectPooling;
        [SerializeField] private ObjectSettings _objectSettings;

        #endregion
        
        #region Objects
        
        [Header("Objects")]
        [SerializeField] private Transform _player;

        #endregion

        #region Properties
        
        private int _amountOfSpawnedBackgrounds;
        private int _amountOfSpawnedBoosters;
        private int _amountOfSpawnedBorders;
        private int _amountOfSpawnedObstacles;

        private Vector3 _backgroundStartPoint;
        private Vector3 _boosterStartPoint;
        private Vector3 _bordersStartPoint;
        private Vector3 _obstacleStartPoint;
        
        #endregion
        
        #region MonoBehaviour methods

        private void Awake()
        {
            CreateSingleton();

            _amountOfSpawnedBackgrounds = 0;
            _amountOfSpawnedBoosters = 0;
            _amountOfSpawnedBorders = 0;
            _amountOfSpawnedObstacles = 0;
            
            _gameCycle.OnGameStart += () => SpawnObjectForFirstTime(ObjectType.Obstacle, ref _obstacleStartPoint);
        }
        private void Start()
        {
            SpawnObjectForFirstTime(ObjectType.Background, ref _backgroundStartPoint);
            SpawnObjectForFirstTime(ObjectType.Borders, ref _bordersStartPoint);
        }

        #endregion

        #region Methods

        private void InitializeStartPoint(ref Vector3 startPoint)
        {
            startPoint = _player.position;
        }
        
        private void SpawnObject(ObjectType objectType, ref int amountOfSpawnedObjects, ref Vector3 startPoint, int amountOfObjectsToSpawn = 1)
        {
            ObjectInfo objectInfo = _objectSettings.GetObjectInfoFromObjectType(objectType);
            for (var i = 0; i < amountOfObjectsToSpawn; i++)
            {
                GameObject newObject = _objectPooling.GetObject(objectInfo.ObjectType);
                
                float xAxisError = Random.Range(objectInfo.AllowedErrorRangeForAxisX.x, objectInfo.AllowedErrorRangeForAxisX.y);
                float yAxisError = Random.Range(objectInfo.AllowedErrorRangeForAxisY.x, objectInfo.AllowedErrorRangeForAxisY.y);
                Vector3 error = new Vector3(xAxisError, yAxisError, 0);
                newObject.transform.position = 
                    startPoint + objectInfo.SpawnOffsetFromStart + 
                    Vector3.right * objectInfo.DistanceBetweenObjects * amountOfSpawnedObjects +
                    error;

                amountOfSpawnedObjects += 1;
            }
        }
        public void SpawnObject(ObjectType objectType, int amountOfObjectsToSpawn = 1)
        {
            switch (objectType)
            {
                case ObjectType.Background:
                    SpawnObject(objectType, ref _amountOfSpawnedBackgrounds, ref _backgroundStartPoint, amountOfObjectsToSpawn);
                    break;
                case ObjectType.Booster:
                    SpawnObject(objectType, ref _amountOfSpawnedBoosters, ref _boosterStartPoint,  amountOfObjectsToSpawn);
                    break;
                case ObjectType.Borders:
                    SpawnObject(objectType, ref _amountOfSpawnedBorders, ref _bordersStartPoint, amountOfObjectsToSpawn);
                    break;
                case ObjectType.Obstacle:
                    SpawnObject(objectType, ref _amountOfSpawnedObstacles, ref _obstacleStartPoint, amountOfObjectsToSpawn);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        private void SpawnObjectForFirstTime(ObjectType objectType, ref Vector3 startPoint)
        {
            InitializeStartPoint(ref startPoint);

            ObjectInfo objectInfo = _objectSettings.GetObjectInfoFromObjectType(objectType);
            int amountOfObjectsToSpawnAtStart = objectInfo.AmountOfObjectsToSpawnAtStart;
            
            SpawnObject(objectType, amountOfObjectsToSpawnAtStart);
        }

        #endregion
    }
}
