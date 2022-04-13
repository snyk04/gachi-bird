using GachiBird.Customization;

namespace GachiBird.Serialization
{
    public class CurrentSkinIdSaver
    {
        public CurrentSkinIdSaver(IGameSaver gameSaver, IPlayerCustomizer playerCustomizer)
        {
            playerCustomizer.OnPlayerSkinChange += gameSaver.SaveCurrentSkinId;
        }
    }
}