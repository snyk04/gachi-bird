using System;
using UnityEngine;

namespace AreYouFruits.Common.ComponentGeneration
{
    public class Test : MonoBehaviour, IDisposable
    {
        [SerializeField] private SerializedInterface<IDisposable> _serializedObject;
        public void Dispose() { }
    }
}
