using System;
using GachiBird.Environment.Objects;

namespace GachiBird.CameraMovement
{
    public interface IFlexDependentCameraEffect : ICameraEffect
    {
        event Action? OnEnable;
        event Action? OnDisable;

        void Enable(BoosterInfo boosterInfo);
        void Disable();
    }
}