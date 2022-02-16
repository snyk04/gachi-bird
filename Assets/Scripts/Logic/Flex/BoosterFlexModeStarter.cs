using GachiBird.Environment;
using GachiBird.Environment.Objects;

namespace GachiBird.Flex
{
    public sealed class BoosterFlexModeStarter
    {
        private readonly IFlexModeHandler _flexModeHandler;
        // TODO : Use IPool<>
        public BoosterFlexModeStarter(IFlexModeHandler flexModeHandler, IBoosterSpawner boosterSpawner)
        {
            _flexModeHandler = flexModeHandler;
            
            boosterSpawner.OnBoosterSpawned += HandleBoosterSpawned;
        }
        
        private void HandleBoosterSpawned(IBooster booster)
        {
            booster.PickedUp += _flexModeHandler.StartFlexMode;
        }
    }
}