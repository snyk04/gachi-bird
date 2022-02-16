using System;
using GachiBird.Flex.Visual;

namespace GachiBird.Flex
{
    public sealed class FlexRenderFeatureHandler : IDisposable
    {
        private readonly PostFXFeature _flexRenderFeature;

        public FlexRenderFeatureHandler(IFlexModeHandler flexModeHandler, PostFXFeature flexRenderFeature)
        {
            _flexRenderFeature = flexRenderFeature;
            _flexRenderFeature.IsActive = false;

            flexModeHandler.OnFlexModeStart += _ => _flexRenderFeature.IsActive = true;
            flexModeHandler.OnFlexModeEnd += () => _flexRenderFeature.IsActive = false;
        }

        public void Dispose() => _flexRenderFeature.IsActive = false;
    }
}