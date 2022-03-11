using GachiBird.Game;
using GooglePlayGames;
using UnityEngine;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoardUpdater
    {
        private readonly IScoreHolder _scoreHolder;

        public LeaderBoardUpdater(IScoreHolder scoreHolder)
        {
            _scoreHolder = scoreHolder;

            _scoreHolder.OnHighScoreChanged += Update;

            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate(success => {});
        }

        public void OnDestroy()
        {
            PlayGamesPlatform.Instance.SignOut();
        }

        private void Update()
        {
            // TODO : Publish game to make it work
            // Social.ReportScore(_scoreHolder.HighScore, GPGSIds.leaderboard_best_slaves, success => {});
        }
    }
}