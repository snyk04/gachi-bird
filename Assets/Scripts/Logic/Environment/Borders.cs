#nullable enable

using System;
using UnityEngine;

namespace GachiBird.Environment
{
    [Serializable]
    public struct Borders
    {
#nullable disable
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
#nullable enable

        public float LeftBorder => _leftBorder;
        public float RightBorder => _rightBorder;
        
        public Borders(float leftBorder, float rightBorder)
        {
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
        }

        public readonly void Deconstruct(out float leftBorder, out float rightBorder)
        {
            leftBorder = _leftBorder;
            rightBorder = _rightBorder;
        }
    }
}