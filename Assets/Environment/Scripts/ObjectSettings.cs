using System.Collections.Generic;
using Environment.Objects;
using UnityEngine;

namespace Environment
{
    public sealed class ObjectSettings : MonoBehaviour
    {
        #region Properties

        [SerializeField] private ObjectInfo _backgroundSettings = new ObjectInfo(ObjectType.Background);
        [SerializeField] private ObjectInfo _boosterSettings = new ObjectInfo(ObjectType.Booster);
        [SerializeField] private ObjectInfo _bordersSettings = new ObjectInfo(ObjectType.Borders);
        [SerializeField] private ObjectInfo _obstacleSettings = new ObjectInfo(ObjectType.Obstacle);
        
        private Dictionary<ObjectType, ObjectInfo> _objectTypeToInfo;
        public Dictionary<ObjectType, ObjectInfo>.ValueCollection ObjectInfos => _objectTypeToInfo.Values;

        #endregion

        #region MonoBehaviour methods

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

        #endregion

        #region Methods

        public ObjectInfo GetObjectInfoFromObjectType(ObjectType objectType)
        {
            return _objectTypeToInfo[objectType];
        }

        #endregion
    }
}
