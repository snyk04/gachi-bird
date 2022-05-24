using GachiBird.Customization;
using GachiBird.UserInterface.MusicList;

namespace Logic.Audio
{
    public class SelectSkinSound
    {
        public SelectSkinSound(IPlayerCustomizer playerCustomizer, IAudioPlayer audioPlayer)
        {
            playerCustomizer.OnPlayerSkinSelect += playerSkinInfo => audioPlayer.Play(playerSkinInfo.SelectSound);
        }
    }
}