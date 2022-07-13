using GachiBird.Environment.Objects;
using System;
using System.Threading.Tasks;
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
            await Task.Delay(TimeSpan.FromSeconds(1.0f));
            OnFlexModeStart?.Invoke(boosterInfo);
        }

        public void Dispose() => OnFlexModeEnd?.Invoke();
    }
}