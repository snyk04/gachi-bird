using System.Collections.Generic;
using GachiBird.Game;

namespace GachiBird.LeaderBoard
{
    public interface ILeaderBoard
    {
        Dictionary<string, long> BestScores { get; }
    }
    public class LeaderBoard : ILeaderBoard
    {
        private readonly IScoreHolder _scoreHolder;
        private readonly IDatabaseManager _databaseManager;
        private readonly string _userName;

        public Dictionary<string, long> BestScores => _databaseManager.BestScores;

        public LeaderBoard(IScoreHolder scoreHolder, IDatabaseManager databaseManager, string userName)
        {
            _scoreHolder = scoreHolder;
            _databaseManager = databaseManager;
            _userName = userName;

            _scoreHolder.OnHighScoreChanged += Update;
        }

        private void Update()
        {
            _databaseManager.AddNewBestScore(_userName, _scoreHolder.HighScore);
        }
    }
}