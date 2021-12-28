using GachiBird.Environment.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObjectPooling : MonoBehaviour
    {
        [SerializeField] private ObjectSettings _objectSettings;
        
        private Dictionary<ObjectType, Pool> _pools;
        
        private void Awake()
        {
            _pools = new Dictionary<ObjectType, Pool>();
        }
        private void Start()
        {
            InitializePools();
        }
        
        public GameObject GetObject(ObjectType type)
        {
            Pool pool = _pools[type];
            if (pool.AvailableObjects.Count == 0)
            {
                ReturnObject(type);
            }

            GameObject newObject = pool.AvailableObjects.Dequeue();
            pool.BusyObjects.Enqueue(newObject);
            newObject.SetActive(true);

            return newObject;
        }

        private GameObject CreateObjectContainer(GameObject prefab, Transform parent, string objectName)
        {
            GameObject container = Instantiate(prefab, parent, false);
            container.name = objectName;

            return container;
        }
        private GameObject CreateObject(GameObject prefab, Transform parent)
        {
            GameObject newObject = Instantiate(prefab, parent);
            newObject.SetActive(false);

            return newObject;
        }
        private void PutObjectIntoThePool(GameObject obj, Queue<GameObject> pool)
        {
            pool.Enqueue(obj);
        }
        
        private void ReturnObject(ObjectType type)
        {
            Pool objectPool = _pools[type];
            GameObject objectToReturn = objectPool.BusyObjects.Dequeue();
            
            PutObjectIntoThePool(objectToReturn, objectPool.AvailableObjects);
            objectToReturn.SetActive(false);
        }
        
        private void InitializePools()
        {
            GameObject containerPrefab = new GameObject();

            foreach (var objectInfo in _objectSettings.ObjectInfos)
            {
                GameObject container = CreateObjectContainer(containerPrefab, transform, 
                    objectInfo.ObjectType.ToString());

                _pools[objectInfo.ObjectType] = new Pool();
                for (var i = 0; i < objectInfo.AmountOfObjectsInPool; i++)
                {
                    GameObject newObject = CreateObject(objectInfo.Prefab, container.transform);
                    PutObjectIntoThePool(newObject, _pools[objectInfo.ObjectType].AvailableObjects);
                }
            }

            Destroy(containerPrefab);
        }
    }
}
