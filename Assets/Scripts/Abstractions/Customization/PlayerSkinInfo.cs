using System;
using UnityEngine;

namespace GachiBird.Customization
{
    [Serializable]
    public struct PlayerSkinInfo
    {
        public int Id;
        public string Name;
        public int Price;
        public Sprite Sprite;
        public Sprite ShopImage;
        public AudioClip[] SelectSounds;
    }
}