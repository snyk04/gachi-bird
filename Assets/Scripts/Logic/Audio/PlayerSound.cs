using AreYouFruits.Common;
using GachiBird.Flex;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Audio
{
    public class PlayerSound
    {
        private bool _isMuted;
        
        public PlayerSound(IFlexModeHandler flexModeHandler, IGameCycle gameCycle, IJumpable playerJumper,
            IScoreHolder scoreHolder, AudioSource jumpAudioSource, AudioSource otherAudioSource, AudioClip[] deathSounds,
            AudioClip jumpSound, AudioClip[] checkpointPassedSounds)
        {
            gameCycle.OnGameEnd += () => Play(otherAudioSource, deathSounds);
            playerJumper.OnJump += () => Play(jumpAudioSource, jumpSound);
            scoreHolder.OnScoreChanged += () => Play(otherAudioSource, checkpointPassedSounds);

            flexModeHandler.OnFlexModeStart += _ => _isMuted = true;
            flexModeHandler.OnFlexModeEnd += () => _isMuted = false;
        }

        private void Play(AudioSource audioSource, AudioClip audioClip)
        {
            if (!_isMuted)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
        private void Play(AudioSource audioSource, AudioClip[] audioClips)
        {
            Play(audioSource, audioClips.GetRandomElement());
        }
    }
}