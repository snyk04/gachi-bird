using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public class FlexModeHandlerComponent : AbstractComponent<IFlexModeHandler>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IBoosterSpawner> _boosterSpawner;
        [SerializeField] private AudioSource _backgroundMusicAudioSource;
        [SerializeField] private AudioSource _flexMusicAudioSource;
#nullable enable
        
        private void OnDestroy()
        {
            HeldItem.Dispose();
        }
        
        protected override IFlexModeHandler Create()
        {
            return new FlexModeHandler(_boosterSpawner.HeldItem, _backgroundMusicAudioSource, _flexMusicAudioSource);
        }
    }
}