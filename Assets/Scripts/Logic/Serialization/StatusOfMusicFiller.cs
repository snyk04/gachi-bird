using System.Collections.Generic;
using GachiBird.Environment;
using GachiBird.Environment.Objects;

namespace GachiBird.Serialization
{
    public class StatusOfMusicFiller
    {
        private readonly IGameSaver _gameSaver;
        private readonly IBoosterSpawner _boosterSpawner;

        public StatusOfMusicFiller(IGameSaver gameSaver, IBoosterSpawner boosterSpawner)
        {
            _gameSaver = gameSaver;
            _boosterSpawner = boosterSpawner;

            FillStatusOfSkins();
        }

        private void FillStatusOfSkins()
        {
            Dictionary<int, bool> statusOfMusic = _gameSaver.LoadStatusOfMusic();
            foreach (BoosterInfo boosterInfo in _boosterSpawner.BoosterInfos)
            {
                if (!statusOfMusic.ContainsKey(boosterInfo.Id))
                {
                    statusOfMusic.Add(boosterInfo.Id, true);
                }
            }
            
            _gameSaver.SaveStatusOfMusic(statusOfMusic);
        }
    }
}