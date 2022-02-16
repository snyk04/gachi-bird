using AreYouFruits.Common.Collections.InterfaceExtensions;
using GachiBird.CameraMovement;

namespace GachiBird.Flex
{
    public sealed class FlexCameraEffects
    {
        private readonly IControllableCameraEffect[] _cameraEffects;

        public FlexCameraEffects(IFlexModeHandler flexModeHandler, IControllableCameraEffect[] cameraEffects)
        {
            _cameraEffects = cameraEffects;

            flexModeHandler.OnFlexModeStart += _ => SetCameraEffectsActive(true);
            flexModeHandler.OnFlexModeEnd += () => SetCameraEffectsActive(false);
        }

        private void SetCameraEffectsActive(bool isActive)
        {
            _cameraEffects.Foreach(cameraEffect => cameraEffect.IsEnabled = isActive);
        }
    }
}