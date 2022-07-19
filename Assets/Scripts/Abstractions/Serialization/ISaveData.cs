using System.Collections.Generic;

namespace GachiBird.Serialization
{
    public interface ISaveData
    {
        int BestScore { get; set; }
        int CurrentSkinId { get; set; }
        int AmountOfMoney { get; set; }
        IReadOnlyDictionary<int, bool> StatusOfSkins { get; set; }
        IReadOnlyDictionary<int, bool> StatusOfMusic { get; set; }
    }
}