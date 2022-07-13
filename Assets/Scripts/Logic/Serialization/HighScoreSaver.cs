using GachiBird.Game;

namespace GachiBird.Serialization
{
    public class HighScoreSaver
    {
        public HighScoreSaver(IGameSaver gameSaverLoader, IScoreHolder scoreHolder)
        {
            scoreHolder.OnHighScoreChanged += () => gameSaverLoader.BestScore = scoreHolder.HighScore;
        }
    }
}