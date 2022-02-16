using System;

namespace GachiBird.PlayerLogic
{
    public interface IJumpable
    {
        event Action? OnJump;
        
        void Jump();
    }
}
