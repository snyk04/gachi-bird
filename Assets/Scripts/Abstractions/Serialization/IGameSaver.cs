namespace GachiBird.Serialization
{
    // TODO : Use public properties instead of methods without arguments (maybe???)
    public interface IGameSaver
    {
        int LoadBestScore();
        string LoadUserName();

        void SaveHighScore(int score);
        void SaveUserName(string username);
    }
}
