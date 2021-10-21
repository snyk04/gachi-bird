using UnityEngine;

namespace AudioHandling
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class BackgroundMusic : MonoBehaviour
    {
        private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] [Range(0, 1)] private float _musicVolume;
        
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
        
        private void Pause()
        {
            _audioSource.Pause();
        }
        private void UnPause()
        {
            _audioSource.UnPause();
        }
    }
}
