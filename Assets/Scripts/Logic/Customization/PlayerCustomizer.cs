using System;
using Components.Customization;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.Customization
{
    public class PlayerCustomizer : IPlayerCustomizer
    {
        private readonly IGameSaver _gameSaver;
        private readonly SpriteRenderer _spriteRenderer;

        public event Action<int>? OnPlayerSkinChange;

        public PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        public PlayerCustomizer(IGameSaver gameSaver, SpriteRenderer spriteRenderer, PlayerSkinInfo[] playerSkins)
        {
            _gameSaver = gameSaver;
            _spriteRenderer = spriteRenderer;
            PlayerSkinInfoArray = playerSkins;
            
            ChangePlayerSkin(_gameSaver.LoadCurrentSkinId());
        }

        public void ChangePlayerSkin(int skinId)
        {
            _gameSaver.SaveCurrentSkinId(skinId);
            
            OnPlayerSkinChange?.Invoke(skinId);
            _spriteRenderer.sprite = PlayerSkinInfoArray[skinId].Sprite;
        }
    }
}