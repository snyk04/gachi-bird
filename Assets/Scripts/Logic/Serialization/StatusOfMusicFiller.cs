using System.Collections.Generic;
using GachiBird.Environment;
using GachiBird.Environment.Objects;

namespace GachiBird.Serialization
{
    public class StatusOfMusicFiller
    {
        private readonly IGameSaverLoader _gameSaverLoader;
        private readonly IBoosterSpawner _boosterSpawner;

        public StatusOfMusicFiller(IGameSaverLoader gameSaverLoader, IBoosterSpawner boosterSpawner)
        {
            _gameSaverLoader = gameSaverLoader;
            _boosterSpawner = boosterSpawner;

            FillStatusOfMusic();
        }

        private void FillStatusOfMusic()
        {
            var statusOfMusic = new Dictionary<int, bool>(_gameSaverLoader.MusicStatus);
            
            foreach (BoosterInfo boosterInfo in _boosterSpawner.BoosterInfos)
            {
                if (!statusOfMusic.ContainsKey(boosterInfo.Id))
                {
                    statusOfMusic.Add(boosterInfo.Id, true);
                }
            }
            
            _gameSaverLoader.MusicStatus = statusOfMusic;
        }
    }
}