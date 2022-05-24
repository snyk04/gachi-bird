using System;
using GachiBird.Customization;

namespace GachiBird.UserInterface.Shop
{
    public interface IApprover
    {
        event Action OnApproval;
        
        void CallForApproval(PlayerSkinInfo playerSkinInfo);
    }
}