using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Flex.Visual;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexRenderFeatureHandlerComponent : DestroyableAbstractComponent<FlexRenderFeatureHandler>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private PostFXFeature _flexRenderFeature;
#nullable enable
        
        protected override FlexRenderFeatureHandler Create()
        {
            return new FlexRenderFeatureHandler(_flexModeHandler.GetHeldItem(), _flexRenderFeature);
        }
    }
}