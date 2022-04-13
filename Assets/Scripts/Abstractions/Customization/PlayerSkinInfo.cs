using System;
using UnityEngine;

namespace Components.Shop
{
    [Serializable]
    public struct PlayerSkinInfo
    {
        public string Name;
        public byte Price;
        public Sprite Sprite;
        public Sprite ShopPage;
    }
}