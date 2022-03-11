using GachiBird.Game;

namespace GachiBird.LeaderBoard
{
    public class LeaderBoardUpdater
    {
        private readonly IScoreHolder _scoreHolder;

        public LeaderBoardUpdater(IScoreHolder scoreHolder)
        {
            _scoreHolder = scoreHolder;

            _scoreHolder.OnHighScoreChanged += Update;
        }

        private void Update()
        {
            // TODO : Interaction with GPS leaderboard
        }
    }
}