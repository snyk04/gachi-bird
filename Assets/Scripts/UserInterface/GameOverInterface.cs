using TMPro;
using UnityEngine;

namespace UserInterface
{
    public sealed class GameOverInterface : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private SerializationManager _serializationManager;
        
        [Header("Objects")]
        [SerializeField] private TextMeshProUGUI _currentScoreText;
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        [SerializeField] private GameObject _interfaceContainer;
        
        private void Awake()
        {
            _gameCycle.OnGameEnd += ShowInterface;
            _gameCycle.OnGameEnd += ShowResultScore;
        }
        
        private void ShowInterface()
        {
            _interfaceContainer.SetActive(true);
        }
        private void HideInterface()
        {
            _interfaceContainer.SetActive(false);
        }
    
        private void ConfigureCurrentScoreContainer()
        {
            _currentScoreText.text = _scoreManager.Score.ToString();
        }
        private void ConfigureBestScoreContainer()
        {
            _bestScoreText.text = _serializationManager.LoadBestScore().ToString();
        }
        private void ShowResultScore()
        {
            ConfigureCurrentScoreContainer();
            ConfigureBestScoreContainer();
        }
    }
}
