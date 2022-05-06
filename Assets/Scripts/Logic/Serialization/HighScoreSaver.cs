using GachiBird.Game;

namespace GachiBird.Serialization
{
    public class HighScoreSaver
    {
        public HighScoreSaver(IGameSaver gameSaver, IScoreHolder scoreHolder)
        {
            scoreHolder.OnHighScoreChanged += () => gameSaver.SaveHighScore(scoreHolder.HighScore);
        }
    }
}