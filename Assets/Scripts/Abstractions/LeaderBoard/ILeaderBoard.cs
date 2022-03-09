using System.Collections.Generic;

namespace GachiBird.LeaderBoard
{
    public interface ILeaderBoard
    {
        Dictionary<string, long> BestScores { get; }
    }
}