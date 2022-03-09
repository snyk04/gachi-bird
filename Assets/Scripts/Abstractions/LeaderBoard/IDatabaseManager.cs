using System.Collections.Generic;

namespace GachiBird.LeaderBoard
{
    public interface IDatabaseManager
    {
        void AddNewBestScore(string userName, long bestScore);
        Dictionary<string, long> GetBestScores();
    }
}