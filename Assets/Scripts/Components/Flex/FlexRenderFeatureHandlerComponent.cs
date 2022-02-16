using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Flex.Visual;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexRenderFeatureHandlerComponent : AbstractComponent<FlexRenderFeatureHandler>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private PostFXFeature _flexRenderFeature;
#nullable disable
        
        protected override FlexRenderFeatureHandler Create()
        {
            return new FlexRenderFeatureHandler(_flexModeHandler.HeldItem, _flexRenderFeature);
        }
    }
}