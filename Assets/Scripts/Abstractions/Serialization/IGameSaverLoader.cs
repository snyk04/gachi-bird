using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GachiBird.Serialization
{
    // TODO : Why Load*() is in IGameSaver?
    public interface IGameSaverLoader : IGameSaver, IGameLoader
    {
        new int BestScore
        {
            get => ((IGameLoader)this).BestScore;
            set => ((IGameSaver)this).BestScore = value;
        }

        new int SkinId
        {
            get => ((IGameLoader)this).SkinId;
            set => ((IGameSaver)this).SkinId = value;
        }

        new int MoneyAmount
        {
            get => ((IGameLoader)this).MoneyAmount;
            set => ((IGameSaver)this).MoneyAmount = value;
        }

        new IReadOnlyDictionary<int, bool> SkinStatus
        {
            get => ((IGameLoader)this).SkinStatus;
            set => ((IGameSaver)this).SkinStatus = value;
        }

        new IReadOnlyDictionary<int, bool> MusicStatus
        {
            get => ((IGameLoader)this).MusicStatus;
            set => ((IGameSaver)this).MusicStatus = value;
        }
    }

    public interface IGameSaver
    {
        int BestScore { set; }
        int SkinId { set; }
        int MoneyAmount { set; }
        IReadOnlyDictionary<int, bool> SkinStatus { set; }
        IReadOnlyDictionary<int, bool> MusicStatus { set; }
    }

    public interface IGameLoader
    {
        int BestScore { get; }
        int SkinId { get; }
        int MoneyAmount { get; }
        IReadOnlyDictionary<int, bool> SkinStatus { get; }
        IReadOnlyDictionary<int, bool> MusicStatus { get; }
    }
}
