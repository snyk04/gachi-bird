using System.Collections.Generic;
using GachiBird.Flex;

namespace GachiBird.Serialization
{
    public class StatusOfMusicUpdater
    {
        public StatusOfMusicUpdater(IGameSaverLoader gameSaverLoader, IFlexModeHandler flexModeHandler)
        {
            flexModeHandler.OnFlexModeStart += info =>
            {
                var statusOfMusic = new Dictionary<int, bool>(gameSaverLoader.MusicStatus);
                statusOfMusic[info.Id] = true;
                gameSaverLoader.MusicStatus = statusOfMusic;
            };
        }
    }
}