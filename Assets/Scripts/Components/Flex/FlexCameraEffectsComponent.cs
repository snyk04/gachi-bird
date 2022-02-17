using AreYouFruits.Common.ComponentGeneration;
using GachiBird.CameraMovement;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexCameraEffectsComponent : AbstractComponent<FlexCameraEffects>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IControllableCameraEffect>>[] _controllableCameraEffects;
#nullable enable
        
        protected override FlexCameraEffects Create()
        {
            return new FlexCameraEffects(_flexModeHandler.GetHeldItem(), _controllableCameraEffects.ExtractAsArray());
        }
    }
}