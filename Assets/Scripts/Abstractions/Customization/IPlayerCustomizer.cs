using System;
using Components.Shop;

namespace GachiBird.Customization
{
    public interface IPlayerCustomizer
    {
        event Action<int> OnPlayerSkinChange;

        PlayerSkinInfo[] PlayerSkinInfoArray { get; }
        
        void ChangePlayerSkin(byte skinId);
    }
}