using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Flex;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Audio
{
    public class PlayerSoundComponent : AbstractComponent<PlayerSound>
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private AbstractComponent<IFlexModeHandler> _flexModeHandler;
        [SerializeField] private AbstractComponent<PlayerFaller> _playerFaller;
        [SerializeField] private AbstractComponent<IJumpable> _playerJumper;
        [SerializeField] private AbstractComponent<IScoreHolder> _scoreHolder;
        
        [Header("Audio")]
        [SerializeField] private AudioSource _jumpAudioSource;
        [SerializeField] private AudioSource _otherAudioSource;
        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _checkpointPassedSound;
#nullable enable
        
        protected override PlayerSound Create()
        {
            return new PlayerSound(_flexModeHandler.HeldItem, _playerFaller.HeldItem, _playerJumper.HeldItem,
                _scoreHolder.HeldItem, _jumpAudioSource, _otherAudioSource, _deathSound,
                _jumpSound, _checkpointPassedSound);
        }
    }
}