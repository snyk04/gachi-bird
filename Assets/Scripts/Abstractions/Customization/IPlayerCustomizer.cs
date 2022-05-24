using System;

namespace GachiBird.Customization
{
    public interface IPlayerCustomizer
    {
        event Action<int> OnPlayerSkinChange;
        event Action<int> OnPlayerSkinPurchase;

        PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        void TryToChangeSkin(PlayerSkinInfo playerSkinInfo);
        bool IsSkinSelected(int skinId);
        bool IsSkinLocked(int skinId);
    }
}