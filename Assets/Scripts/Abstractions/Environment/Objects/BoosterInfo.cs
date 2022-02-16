using System;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [Serializable]
    public struct BoosterInfo
    {
        public int Id;
        public Sprite Sprite;
        public float GameSpeed;
        public AudioClip Music;
        // public int[] MusicFrequencyRange;
    }
}