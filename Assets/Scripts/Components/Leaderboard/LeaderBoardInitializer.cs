using GooglePlayGames;
using UnityEngine;

namespace GachiBird.Leaderboard
{
    public class LeaderBoardInitializer : MonoBehaviour
    {
        private void Awake()
        {
            PlayGamesPlatform.Instance.Authenticate(_ => { });
            PlayGamesPlatform.DebugLogEnabled = true;
        }
    }
}