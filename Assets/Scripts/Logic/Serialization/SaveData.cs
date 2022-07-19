using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GachiBird.Serialization
{
    [Serializable]
    public class SaveData : ISaveData
    {
        public int BestScore { get; set; }
        public int CurrentSkinId { get; set; }
        public int AmountOfMoney { get; set; }
        
        public IReadOnlyDictionary<int, bool> StatusOfSkins { get; set; }
        public IReadOnlyDictionary<int, bool> StatusOfMusic { get; set; }

        public SaveData()
        {
            BestScore = 0;
            AmountOfMoney = 0;
            CurrentSkinId = 0;
            StatusOfMusic = new ReadOnlyDictionary<int, bool>(new Dictionary<int, bool>());
            StatusOfSkins = new ReadOnlyDictionary<int, bool>(new Dictionary<int, bool>());
        }
    }
}