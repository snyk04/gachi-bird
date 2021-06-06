using UnityEngine;

public class Booster : MonoBehaviour
{
    #region Properties

    private FlexModeManager flexMode;
    private GameStateManager gameState;
    private SerializationManager serializationManager;

    public AudioClip audioClip;
    public int iD;
    public float speedCoefficient;
    private float length;

    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        flexMode = FindObjectOfType<FlexModeManager>();
        gameState = FindObjectOfType<GameStateManager>();
        serializationManager = SerializationManager.Instance;

        length = audioClip.length;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameState.IsGameInFlexMode)
        {
            return;
        }
        
        gameObject.SetActive(false);
        gameState.StatusOfMusicDict[iD] = true;
        serializationManager.SaveStatusOfMusic(gameState.StatusOfMusicDict);
        flexMode.StartFlexingForFixedTime(length, speedCoefficient, audioClip);
    }

    #endregion
}
