using System;
using System.Collections.Generic;

namespace GachiBird.Serialization
{
    [Serializable]
    public class SaveData
    {
        public bool IsFirstLaunch = true;
        public int BestScore = 0;
        public int CurrentSkinId = 0;
        public int AmountOfMoney = 0;
        public Dictionary<int, bool> StatusOfSkins = new Dictionary<int, bool> {[0] = true};
        public Dictionary<int, bool> StatusOfMusic = new Dictionary<int, bool>();
    }
}