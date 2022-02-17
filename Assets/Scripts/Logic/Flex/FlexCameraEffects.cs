using AreYouFruits.Common.Collections.InterfaceExtensions;
using GachiBird.CameraMovement;

namespace GachiBird.Flex
{
    public sealed class FlexCameraEffects
    {
        public FlexCameraEffects(IFlexModeHandler flexModeHandler, IFlexDependentCameraEffect[] cameraEffects)
        {
            flexModeHandler.OnFlexModeStart += boosterInfo => cameraEffects.Foreach(cameraEffect => cameraEffect.Enable(boosterInfo));
            flexModeHandler.OnFlexModeEnd += () => cameraEffects.Foreach(cameraEffect => cameraEffect.Disable());
        }
    }
}