namespace GachiBird.Serialization
{
    public interface IGameSaver
    {
        int LoadBestScore();

        void SaveHighScore(int score);
    }
}
