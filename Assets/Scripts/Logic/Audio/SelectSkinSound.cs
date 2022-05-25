using GachiBird.Customization;
using GachiBird.UserInterface.MusicList;
using UnityEngine;

namespace GachiBird.Audio
{
    public class SelectSkinSound
    {
        public SelectSkinSound(IPlayerCustomizer playerCustomizer, IAudioPlayer audioPlayer)
        {
            playerCustomizer.OnPlayerSkinSelect += playerSkinInfo =>
            {
                int amountOfSelectSounds = playerSkinInfo.SelectSounds.Length;
                AudioClip randomSelectSounds = playerSkinInfo.SelectSounds[Random.Range(0, amountOfSelectSounds)];
                audioPlayer.Play(randomSelectSounds);
            };
        }
    }
}