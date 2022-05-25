using System;

namespace GachiBird.PlayerLogic
{
    public interface IJumpable
    {
        float JumpForce { get; }
        
        event Action? OnJump;
        
        void Jump();
    }
}
