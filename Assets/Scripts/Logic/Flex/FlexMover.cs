using GachiBird.PlayerLogic;

namespace GachiBird.Flex
{
    public sealed class FlexMover
    {
        public FlexMover(IFlexModeHandler flexModeHandler, IMovable mover)
        {
            flexModeHandler.OnFlexModeStart += (boosterInfo) => mover.Speed = boosterInfo.PlayerSpeed;
            // TODO : Reset speed only if game is not over
            flexModeHandler.OnFlexModeEnd += mover.ResetSpeed;
        }
    }
}