using System.Collections.Generic;
using GachiBird.Flex;

namespace GachiBird.Serialization
{
    public class StatusOfMusicUpdater
    {
        public StatusOfMusicUpdater(IGameSaver gameSaver, IFlexModeHandler flexModeHandler)
        {
            flexModeHandler.OnFlexModeStart += info =>
            {
                Dictionary<int, bool> statusOfMusic = gameSaver.LoadStatusOfMusic();
                statusOfMusic[info.Id] = true;
                gameSaver.SaveStatusOfMusic(statusOfMusic);
            };
        }
    }
}