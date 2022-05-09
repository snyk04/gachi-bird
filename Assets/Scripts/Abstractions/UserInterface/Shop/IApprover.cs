using System;
using Components.Customization;

namespace GachiBird.UserInterface.Shop
{
    public interface IApprover
    {
        event Action OnApproval;
        
        void CallForApproval(PlayerSkinInfo playerSkinInfo);
    }
}