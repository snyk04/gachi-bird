using System.Collections.Generic;

namespace GachiBird.LeaderBoard
{
    public interface IDatabaseManager
    {
        Dictionary<string, long> BestScores { get; }
        void AddNewBestScore(string userName, long bestScore);
    }
}