using GachiBird.Flex.Visual;

namespace GachiBird.Flex
{
    public sealed class FlexRenderFeatureHandler
    {
        private readonly PostFXFeature _flexRenderFeature;

        public FlexRenderFeatureHandler(IFlexModeHandler flexModeHandler, PostFXFeature flexRenderFeature)
        {
            _flexRenderFeature = flexRenderFeature;
            SetFlexRenderFeatureActive(false);

            flexModeHandler.OnFlexModeStart += _ => SetFlexRenderFeatureActive(true);
            flexModeHandler.OnFlexModeEnd += () => SetFlexRenderFeatureActive(false);
        }

        private void SetFlexRenderFeatureActive(bool isActive)
        {
            _flexRenderFeature.IsActive = isActive;
        }
    }
}