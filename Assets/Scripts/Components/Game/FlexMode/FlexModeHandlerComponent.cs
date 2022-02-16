using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Game.FlexMode
{
    public sealed class FlexModeHandlerComponent : AbstractComponent<IFlexModeHandler>
    {
#nullable disable
        [SerializeField] private AbstractComponent<IBoosterSpawner> _boosterSpawner;
        [SerializeField] private AbstractComponent<IPlayer> _player;
        [SerializeField] private AudioSource _backgroundMusicAudioSource;
        [SerializeField] private AudioSource _flexMusicAudioSource;
#nullable enable
        
        private void OnDestroy()
        {
            HeldItem.Dispose();
        }
        
        protected override IFlexModeHandler Create()
        {
            return new FlexModeHandler(_boosterSpawner.HeldItem, _player.HeldItem,
                _backgroundMusicAudioSource, _flexMusicAudioSource);
        }
    }
}