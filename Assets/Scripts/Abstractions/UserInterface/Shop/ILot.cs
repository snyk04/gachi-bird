using GachiBird.Customization;

namespace GachiBird.UserInterface.Shop
{
    public interface ILot
    {
        void Setup(IPlayerCustomizer? playerCustomizer, PlayerSkinInfo playerSkinInfo);
    }
}