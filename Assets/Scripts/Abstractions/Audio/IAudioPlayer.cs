using UnityEngine;

namespace GachiBird.UserInterface.MusicList
{
    public interface IAudioPlayer
    {
        void Play(AudioClip audio);
        void Stop();
        void Pause();
        void UnPause();
    }
}