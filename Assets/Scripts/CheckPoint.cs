using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    private GameStateManager gameState;
    private AudioPlayerManager audioPlayer;
    private ScoreManager scoreManager;

    private bool isVisited;

    void Awake()
    {
        gameState = FindObjectOfType<GameStateManager>();
        audioPlayer = FindObjectOfType<AudioPlayerManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        isVisited = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!isVisited) && (!gameState.IsGameStopped)) {
            if (!gameState.IsGameInFlexMode) {
                audioPlayer.PlaySoundFromArray(
                    audioPlayer.plusOnePointSoundArray,
                    audioPlayer.inGameSoundAudioSource
                    );
            }
            isVisited = true;
            gameState.Score += 1;
            gameState.AmountOfMoney += 1;
            scoreManager.RefreshScoreCounter();
        }
    }
}
