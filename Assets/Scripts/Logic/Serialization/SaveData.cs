using System;

namespace GachiBird.Serialization
{
    [Serializable]
    public class SaveData
    {
        public bool IsFirstLaunch = true;
        public int BestScore = 0;
        public int CurrentSkinId = 0;
        public int AmountOfMoney = 0;
        public bool[] StatusOfSkins = Array.Empty<bool>();
        public bool[] StatusOfMusic = Array.Empty<bool>();
        public string UserName = "";
    }
}
