using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.UserInterface.MusicList
{
    public class AudioPlayerComponent : AbstractComponent<AudioPlayer>
    {
#nullable disable
        [SerializeField] private AudioSource _audioSource;
#nullable enable
        
        protected override AudioPlayer Create()
        {
            return new AudioPlayer(_audioSource);
        }
    }
}