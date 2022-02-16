using System;

namespace GachiBird.CameraMovement
{
    public interface IControllableCameraEffect : ICameraEffect
    {
        bool IsEnabled { get; set; }

        event Action? OnEnable;
        event Action? OnDisable;
    }
}