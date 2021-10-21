using System.Collections.Generic;
using UnityEngine;

namespace GachiBird.Environment
{
    public sealed class Pool
    {
        #region Properties

        public Queue<GameObject> AvailableObjects { get; }
        public Queue<GameObject> BusyObjects { get; }

        #endregion
        
        public Pool()
        {
            AvailableObjects = new Queue<GameObject>();
            BusyObjects = new Queue<GameObject>();
        }
    }
}
