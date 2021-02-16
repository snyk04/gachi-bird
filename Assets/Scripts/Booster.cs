using UnityEngine;

public class Booster : MonoBehaviour
{
    private FlexModeManager flexMode;
    private GameStateManager gameState;
    private SerializationManager serialization;

    public AudioClip audioClip;
    public int iD;
    public float speedCoefficient;
    private float length;

    void Awake()
    {
        flexMode = FindObjectOfType<FlexModeManager>();
        gameState = FindObjectOfType<GameStateManager>();
        serialization = FindObjectOfType<SerializationManager>();

        length = audioClip.length;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameState.IsGameInFlexMode)
        {
            gameObject.SetActive(false);
            gameState.StatusOfMusicDict[iD] = true;
            serialization.SaveStatusOfMusic(gameState.StatusOfMusicDict);
            flexMode.StartFlexingForFixedTime(length, speedCoefficient, audioClip);
        }
    }
}
