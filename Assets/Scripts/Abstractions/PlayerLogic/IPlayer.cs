using System;

namespace GachiBird.PlayerLogic
{
    public interface IPlayer
    {
        float Speed { set; }
        event Action? OnJump;
        
        void Jump();
        void ResetSpeed();
    }
}
