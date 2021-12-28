using GachiBird.Environment.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class ObjectSettings : MonoBehaviour
    {
        [SerializeField] private ObjectInfo _backgroundSettings = new ObjectInfo(ObjectType.Background);
        [SerializeField] private ObjectInfo _boosterSettings = new ObjectInfo(ObjectType.Booster);
        [SerializeField] private ObjectInfo _bordersSettings = new ObjectInfo(ObjectType.Borders);
        [SerializeField] private ObjectInfo _obstacleSettings = new ObjectInfo(ObjectType.Obstacle);
        
        private Dictionary<ObjectType, ObjectInfo> _objectTypeToInfo;
        public Dictionary<ObjectType, ObjectInfo>.ValueCollection ObjectInfos => _objectTypeToInfo.Values;
        
        private void Awake()
        {
            _objectTypeToInfo = new Dictionary<ObjectType, ObjectInfo>()
            {
                [ObjectType.Background] = _backgroundSettings,
                [ObjectType.Booster] = _boosterSettings,
                [ObjectType.Borders] = _bordersSettings,
                [ObjectType.Obstacle] = _obstacleSettings
            };
        }
        
        public ObjectInfo GetObjectInfoFromObjectType(ObjectType objectType)
        {
            return _objectTypeToInfo[objectType];
        }
    }
}
