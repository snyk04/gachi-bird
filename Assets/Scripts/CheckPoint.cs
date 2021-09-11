using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameStateManager gameState;
    private AudioPlayerManager audioPlayer;

    private bool isVisited;

    private void Awake()
    {
        gameState = FindObjectOfType<GameStateManager>();
        audioPlayer = FindObjectOfType<AudioPlayerManager>();

        isVisited = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!isVisited) && (!gameState.IsGameStopped)) {
            if (!gameState.IsGameInFlexMode) {
                audioPlayer.PlaySoundFromArray(
                    audioPlayer.plusOnePointSoundArray,
                    audioPlayer.inGameSoundAudioSource
                    );
            }
            isVisited = true;
            ScoreManager.Instance.AddPoints(1);
        }
    }
}
