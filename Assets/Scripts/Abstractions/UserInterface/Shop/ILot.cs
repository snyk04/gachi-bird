using System;
using Components.Customization;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;

namespace GachiBird.UserInterface.Shop
{
    public interface ILot
    {
        event Action<ILot> OnSelect;

        void Setup(IGameSaver? gameSaver, IMoneyHolder? moneyHolder, IPlayerCustomizer? playerCustomizer, IApprover? approver,
            PlayerSkinInfo playerSkinInfo);

        void SetSelect(bool isSelected);
        void SetLock(bool isLocked);
    }
}