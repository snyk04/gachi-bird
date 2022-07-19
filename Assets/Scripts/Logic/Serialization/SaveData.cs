using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GachiBird.Serialization
{
    [Serializable]
    public class SaveData
    {
        public bool IsFirstLaunch;
        public int BestScore;
        public int CurrentSkinId;
        public int AmountOfMoney;
        public IReadOnlyDictionary<int, bool> StatusOfSkins;
        public IReadOnlyDictionary<int, bool> StatusOfMusic;

        public static SaveData GetDefault()
        {
            return new SaveData
            {
                IsFirstLaunch = true,
                BestScore = 0,
                AmountOfMoney = 0,
                CurrentSkinId = 0,
                StatusOfMusic = new ReadOnlyDictionary<int, bool>(new Dictionary<int, bool>()),
                StatusOfSkins = new ReadOnlyDictionary<int, bool>(new Dictionary<int, bool>()),
            };
        }
    }
}