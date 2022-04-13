namespace GachiBird.Serialization
{
    // TODO : Use public properties instead of methods without arguments (maybe???)
    public interface IGameSaver
    {
        // TODO : Why Load*() is in IGameSaver?
        int LoadBestScore();

        void SaveHighScore(int score);
        void SaveCurrentSkinId(int skinId);
    }
}
