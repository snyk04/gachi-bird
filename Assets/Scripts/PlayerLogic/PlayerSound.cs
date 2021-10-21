using System;
using UnityEngine;
using GachiBird.UserInterface;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerSound : MonoBehaviour
    {
        private enum SoundType
        {
            Checkpoint,
            Death,
            Jump
        }
        
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private Player _player;
        [SerializeField] private ScoreManager _scoreManager;
        
        [Header("Sound")]
        [SerializeField] private AudioClip _checkpointSound;
        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private AudioClip _jumpSound;
        
        private AudioSource _checkpointAudioSource;
        private AudioSource _deathAndJumpAudioSource;
        
        private void Awake()
        {
            _checkpointAudioSource = gameObject.AddComponent<AudioSource>();
            _deathAndJumpAudioSource = gameObject.AddComponent<AudioSource>();

            _scoreManager.PointGet += () => Play(SoundType.Checkpoint);
            _gameCycle.OnGameEnd += () => Play(SoundType.Death);
            _player.OnJump += () => Play(SoundType.Jump);
        }
        
        public void SetCheckpointSound(AudioClip checkpointSound)
        {
            _checkpointSound = checkpointSound;
        }
        public void SetDeathSound(AudioClip deathSound)
        {
            _checkpointSound = deathSound;
        }
        public void SetJumpSound(AudioClip jumpSound)
        {
            _checkpointSound = jumpSound;
        }
        
        private AudioSource GetAudioSourceBySoundType(SoundType soundType)
        {
            return soundType switch
            {
                SoundType.Checkpoint => _checkpointAudioSource,
                SoundType.Death => _deathAndJumpAudioSource,
                SoundType.Jump => _deathAndJumpAudioSource,
                _ => throw new ArgumentException()
            };
        }
        private AudioClip GetAudioClipBySoundType(SoundType soundType)
        {
            return soundType switch
            {
                SoundType.Checkpoint => _checkpointSound,
                SoundType.Death => _deathSound,
                SoundType.Jump => _jumpSound,
                _ => throw new ArgumentException()
            };
        }

        private void Play(SoundType soundType)
        {
            AudioSource audioSource = GetAudioSourceBySoundType(soundType);
            AudioClip clip = GetAudioClipBySoundType(soundType);

            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
