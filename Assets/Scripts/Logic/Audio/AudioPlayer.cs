using UnityEngine;

namespace GachiBird.UserInterface.MusicList
{
    public class AudioPlayer : IAudioPlayer
    {
        private readonly AudioSource _audioSource;

        public AudioPlayer(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void Play(AudioClip audio)
        {
            _audioSource.clip = audio;
            _audioSource.Play();
        }
        public void Stop()
        {
            _audioSource.Stop();
        }
        public void Pause()
        {
            _audioSource.Pause();
        }
        public void UnPause()
        {
            _audioSource.UnPause();
        }
    }
}