using System;
using Components.Customization;

namespace GachiBird.Customization
{
    public interface IPlayerCustomizer
    {
        event Action<int> OnPlayerSkinChange;

        PlayerSkinInfo[] PlayerSkinInfoArray { get; }
        
        void ChangePlayerSkin(int skinId);
    }
}