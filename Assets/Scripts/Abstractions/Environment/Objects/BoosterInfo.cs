using System;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Environment.Objects
{
    [Serializable]
    public struct BoosterInfo
    {
        public int Id;
        public Sprite Sprite;
        public float PlayerSpeed;
        public AudioClip Music;
        public Range<int> MusicFrequencyRange;
        public string Title;
        public string Author;
    }
}