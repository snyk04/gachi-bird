using System;
using Components.Customization;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizer : IPlayerCustomizer
    {
        private readonly SpriteRenderer _spriteRenderer;

        public event Action<int>? OnPlayerSkinChange;

        public PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        public PlayerCustomizer(SpriteRenderer spriteRenderer, PlayerSkinInfo[] playerSkins)
        {
            _spriteRenderer = spriteRenderer;
            PlayerSkinInfoArray = playerSkins;
        }

        public void ChangePlayerSkin(byte skinId)
        {
            OnPlayerSkinChange?.Invoke(skinId);
            _spriteRenderer.sprite = PlayerSkinInfoArray[skinId].Sprite;
        }
    }
}