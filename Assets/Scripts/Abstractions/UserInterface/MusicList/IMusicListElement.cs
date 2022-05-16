using GachiBird.Environment.Objects;

namespace GachiBird.UserInterface.MusicList
{
    public interface IMusicListElement
    {
        bool IsActive { get; }
        
        public void Setup(BoosterInfo boosterInfo, IAudioPlayer audioPlayer);
        public void Activate();
    }
}