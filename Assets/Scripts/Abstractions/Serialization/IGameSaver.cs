using System.Collections.Generic;

namespace GachiBird.Serialization
{
    // TODO : Use public properties instead of methods without arguments (maybe???)
    // TODO : Why Load*() is in IGameSaver?
    public interface IGameSaver
    {
        int LoadBestScore();
        int LoadCurrentSkinId();
        Dictionary<int, bool> LoadStatusOfSkins();

        void SaveHighScore(int score);
        void SaveCurrentSkinId(int skinId);
        void SaveStatusOfSkins(Dictionary<int, bool> statusOfSkins);
    }
}