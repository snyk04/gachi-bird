using GachiBird.Customization;

namespace GachiBird.Serialization
{
    public class CurrentSkinIdSaver
    {
        public CurrentSkinIdSaver(IGameSaver gameSaverLoader, IPlayerCustomizer playerCustomizer)
        {
            playerCustomizer.OnPlayerSkinSelect += playerSkinInfo => gameSaverLoader.SkinId = playerSkinInfo.Id;
        }
    }
}