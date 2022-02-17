using GachiBird.Environment.Objects;
using System;
using AreYouFruits.Common;
using UnityEngine;

namespace GachiBird.Flex
{
    public class TestFlex : IFlexModeHandler
    {
        public event Action<BoosterInfo>? OnFlexModeStart;
        public event Action? OnFlexModeEnd;

        private readonly BoosterInfo _boosterInfo;

        public TestFlex(BoosterInfo boosterInfo)
        {
            _boosterInfo = boosterInfo;

            StartFlexMode(new GameObject(), null, _boosterInfo);
        }

        public async void StartFlexMode(GameObject boosterObject, IBooster booster, BoosterInfo boosterInfo)
        {
            await Tasks.DelaySeconds(1);
            OnFlexModeStart?.Invoke(boosterInfo);
        }
    }
}