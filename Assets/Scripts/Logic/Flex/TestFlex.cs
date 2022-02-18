using GachiBird.Environment.Objects;
using System;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Flex
{
    public class TestFlex : IFlexModeHandler, IDisposable
    {
        public event Action<BoosterInfo>? OnFlexModeStart;
        public event Action? OnFlexModeEnd;

        public TestFlex(BoosterInfo boosterInfo)
        {
            StartFlexMode(new GameObject(), null, boosterInfo);
        }

        public async void StartFlexMode(GameObject boosterObject, IBooster? booster, BoosterInfo boosterInfo)
        {
            await Tasks.DelaySeconds(1);
            OnFlexModeStart?.Invoke(boosterInfo);
        }

        public void Dispose() => OnFlexModeEnd?.Invoke();
    }
}