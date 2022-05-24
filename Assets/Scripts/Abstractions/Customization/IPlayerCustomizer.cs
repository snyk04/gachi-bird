using System;

namespace GachiBird.Customization
{
    public interface IPlayerCustomizer
    {
        event Action<PlayerSkinInfo> OnPlayerSkinSelect;
        event Action<PlayerSkinInfo> OnPlayerSkinPurchase;

        PlayerSkinInfo[] PlayerSkinInfoArray { get; }

        void TryToChangeSkin(PlayerSkinInfo playerSkinInfo);
        bool IsSkinSelected(int skinId);
        bool IsSkinLocked(int skinId);
    }
}