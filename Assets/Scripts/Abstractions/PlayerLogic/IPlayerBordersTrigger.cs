using System;

namespace GachiBird.PlayerLogic
{
    public interface IPlayerBordersTrigger
    {
        event Action? OnPlayerOutOfBounds;
    }
}
