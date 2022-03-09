using System.Collections.Generic;
using GachiBird.Game;
using GachiBird.Serialization;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoard : ILeaderBoard
    {
        private readonly IScoreHolder _scoreHolder;
        private readonly IDatabaseManager _databaseManager;
        private readonly string _userName;

        public Dictionary<string, long> BestScores => _databaseManager.BestScores;

        public LeaderBoard(IScoreHolder scoreHolder, IDatabaseManager databaseManager, IGameSaver gameSaver)
        {
            _scoreHolder = scoreHolder;
            _databaseManager = databaseManager;
            _userName = gameSaver.LoadUserName();

            _scoreHolder.OnHighScoreChanged += Update;
        }

        private void Update()
        {
            _databaseManager.AddNewBestScore(_userName, _scoreHolder.HighScore);
        }
    }
}