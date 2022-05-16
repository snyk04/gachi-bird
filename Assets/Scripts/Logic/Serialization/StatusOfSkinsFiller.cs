using System.Collections.Generic;
using GachiBird.Environment;
using GachiBird.Environment.Objects;

namespace GachiBird.Serialization
{
    public class StatusOfSkinsFiller
    {
        private readonly IGameSaver _gameSaver;
        private readonly IBoosterSpawner _boosterSpawner;

        public StatusOfSkinsFiller(IGameSaver gameSaver, IBoosterSpawner boosterSpawner)
        {
            _gameSaver = gameSaver;
            _boosterSpawner = boosterSpawner;

            FillStatusOfSkins();
        }

        private void FillStatusOfSkins()
        {
            Dictionary<int, bool> statusOfSkins = _gameSaver.LoadStatusOfSkins();
            foreach (BoosterInfo boosterInfo in _boosterSpawner.BoosterInfos)
            {
                if (!statusOfSkins.ContainsKey(boosterInfo.Id))
                {
                    statusOfSkins.Add(boosterInfo.Id, false);
                }
            }
            
            _gameSaver.SaveStatusOfSkins(statusOfSkins);
        }
    }
}