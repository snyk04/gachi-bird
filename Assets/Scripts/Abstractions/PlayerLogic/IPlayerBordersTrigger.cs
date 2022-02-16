using System;
using AreYouFruits.Common;

namespace GachiBird.PlayerLogic
{
    public interface IPlayerBordersTrigger
    {
        Range<float> HeightBounds { get; }
        event Action? OnPlayerOutOfBounds;
    }
}
