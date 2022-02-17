using GachiBird.Flex;
using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Audio
{
    public class PlayerSound
    {
        private bool _isMuted;
        
        public PlayerSound(IFlexModeHandler flexModeHandler, PlayerFaller playerFaller, IJumpable playerJumper,
            IScoreHolder scoreHolder, AudioSource jumpAudioSource, AudioSource otherAudioSource, AudioClip deathSound,
            AudioClip jumpSound, AudioClip checkpointPassedSound)
        {
            playerFaller.OnFall += () => Play(otherAudioSource, deathSound);
            playerJumper.OnJump += () => Play(jumpAudioSource, jumpSound);
            scoreHolder.OnScoreChanged += () => Play(otherAudioSource, checkpointPassedSound);

            flexModeHandler.OnFlexModeStart += _ => _isMuted = true;
            flexModeHandler.OnFlexModeEnd += () => _isMuted = false;
        }

        private void Play(AudioSource audioSource, AudioClip audioClip)
        {
            if (!_isMuted)
            {
                audioSource.Stop();
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}