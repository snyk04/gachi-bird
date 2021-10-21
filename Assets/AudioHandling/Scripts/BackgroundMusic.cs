using UnityEngine;

namespace AudioHandling
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class BackgroundMusic : MonoBehaviour
    {
        #region Components

        private AudioSource _audioSource;

        #endregion

        #region Settings

        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] [Range(0, 1)] private float _musicVolume;
        
        #endregion

        #region MonoBehaviour methods

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            _audioSource.clip = _backgroundMusic;
            _audioSource.volume = _musicVolume;

            // TODO : subscribe to GameCycle events:
            // GameCycle.OnFlexModeEnter += Pause;
            // GameCycle.OnFlexModeExit += UnPause;
        }
        private void Start()
        {
            _audioSource.Play();
        }

        #endregion

        #region Methods
        
        private void Pause()
        {
            _audioSource.Pause();
        }
        private void UnPause()
        {
            _audioSource.UnPause();
        }

        #endregion
    }
}
