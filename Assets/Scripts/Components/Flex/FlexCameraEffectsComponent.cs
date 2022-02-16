using AreYouFruits.Common.ComponentGeneration;
using GachiBird.CameraMovement;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexCameraEffectsComponent : AbstractComponent<FlexCameraEffects>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<IControllableCameraEffect>[] _controllableCameraEffects;
#nullable enable
        
        protected override FlexCameraEffects Create()
        {
            return new FlexCameraEffects(_flexModeHandler.HeldItem, _controllableCameraEffects.ExtractAsArray());
        }
    }
}