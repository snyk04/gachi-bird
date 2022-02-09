#nullable enable

using System;

namespace GachiBird.PlayerLogic
{
    public interface IPlayer
    {
        event Action? OnJump;
        void Jump();
    }
}
