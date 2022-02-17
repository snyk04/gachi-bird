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
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IJumpable>> _playerJumper;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Audio")]
        [SerializeField] private AudioSource _jumpAudioSource;
        [SerializeField] private AudioSource _otherAudioSource;
        [SerializeField] private AudioClip[] _deathSounds;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip[] _checkpointPassedSounds;
#nullable enable
        
        protected override PlayerSound Create()
        {
            return new PlayerSound(_flexModeHandler.GetHeldItem(), _gameCycle.GetHeldItem(), _playerJumper.GetHeldItem(),
                _scoreHolder.GetHeldItem(), _jumpAudioSource, _otherAudioSource, _deathSounds,
                _jumpSound, _checkpointPassedSounds);
        }
    }
}