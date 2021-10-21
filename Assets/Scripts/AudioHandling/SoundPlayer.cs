using UnityEngine;

namespace AudioHandling
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class SoundPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _sound;
        [SerializeField] private bool _playOnStart;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            _audioSource.clip = _sound;
        }
        private void Start()
        {
            if (_playOnStart)
            {
                Play();
            }
        }

        private void Play()
        {
            _audioSource.Play();
        }
        
        // private void Stop()
        // {
        //     _audioSource.Stop();
        // }
        //
        // private void Pause()
        // {
        //     _audioSource.Pause();
        // }
        // private void UnPause()
        // {
        //     _audioSource.UnPause();
        // }
    }
}
