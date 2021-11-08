using System;
using UnityEngine;

namespace GachiBird.Audio
{
    [Serializable]
    public struct FrequencyRange
    {
        [SerializeField] private int _start;
        [SerializeField] private int _end;

        public int Start => _start;
        public int End => _end;
    }
}
