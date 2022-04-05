namespace GachiBird.Serialization
{
    // TODO : Use public properties instead of methods without arguments (maybe???)
    public interface IGameSaver
    {
        int LoadBestScore();

        void SaveHighScore(int score);
    }
}
