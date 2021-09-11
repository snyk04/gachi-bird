using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Properties

    public static ScoreManager Instance { get; private set; }

    [SerializeField] private SerializationManager _serializationManager;
    [SerializeField] private GameStateManager _gameState;
    [SerializeField] private NumberPainter _numberPainter;
    
    [SerializeField] private GameObject _newBestScoreImage;

    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Methods

    public void AddPoints(int amountOfPoints)
    {
        _gameState.Score += amountOfPoints;
        _gameState.AmountOfMoney += amountOfPoints;
        _numberPainter.RefreshCurrentScoreCounter(_gameState.Score);
    }
    
    public int CurrentBestScore()
    {
        int bestScore;
        int loadedBestScore = _serializationManager.LoadBestScore();
        
        if ((loadedBestScore == -1) || (_gameState.Score > loadedBestScore))
        {
            bestScore = _gameState.Score;
            _serializationManager.SaveBestScore(_gameState.Score);
            _newBestScoreImage.SetActive(true);
        }
        else
        {
            bestScore = loadedBestScore;
        }

        return bestScore;
    }
    
    #endregion
}
