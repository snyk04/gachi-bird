using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class BoosterFlexModeStarter
    {
        private readonly IFlexModeHandler _flexModeHandler;
        private readonly IGameCycle _gameCycle;
        
        // TODO : Use IPool<>
        public BoosterFlexModeStarter(IFlexModeHandler flexModeHandler, IBoosterSpawner boosterSpawner, 
            IGameCycle gameCycle)
        {
            _flexModeHandler = flexModeHandler;
            _gameCycle = gameCycle;
            
            boosterSpawner.OnBoosterSpawned += HandleBoosterSpawned;
        } 
        
        private void HandleBoosterSpawned(IBooster booster)
        {
            booster.PickedUp += HandleBoosterPickedUp;
        }

        private void HandleBoosterPickedUp(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            if (_gameCycle.IsPlaying)
            {
                _flexModeHandler.StartFlexMode(boosterObject, booster, boosterInfo);
            }
        }
    }
}