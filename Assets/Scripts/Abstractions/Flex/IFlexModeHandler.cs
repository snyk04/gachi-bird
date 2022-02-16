using System;
using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Flex
{
    public interface IFlexModeHandler
    {
        event Action<BoosterInfo> OnFlexModeStart;
        event Action OnFlexModeEnd;

        void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo);
    }
}