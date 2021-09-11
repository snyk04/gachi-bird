using System;
using TMPro;
using UnityEngine;

public class NumberPainter : MonoBehaviour
{
    #region Properties

    [SerializeField] private GameStateManager _gameState;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private TMP_Text _currentScoreContainer;
    [SerializeField] private TMP_Text _finalScoreContainer;
    [SerializeField] private TMP_Text _bestScoreContainer;
    [SerializeField] private TMP_Text _amountOfMoneyContainer;

    [SerializeField] private GameObject _newBestScoreImage;
    
    #endregion

    #region Methods

    public static void DrawNumber(int number, TMP_Text container)
    {
        string thingToPutInContainer;

        var numberLength = number.ToString().Length;
        if (numberLength <= 4)
        {
            thingToPutInContainer = number.ToString();
        }
        else
        {
            var closestLengthWithLetter = numberLength - (numberLength - 1) % 3;
            
            string letter = closestLengthWithLetter switch
            {
                4 => "K",
                7 => "M",
                10 => "B",
                13 => "t",
                _ => ""
            };

            thingToPutInContainer = Math.Round(number / Math.Pow(10, closestLengthWithLetter - 1)) + letter;
        }

        container.text = thingToPutInContainer;
    }

    public static void ShowNumber(TMP_Text container)
    {
        container.gameObject.SetActive(true);
    }
    public static void HideNumber(TMP_Text container)
    {
        container.gameObject.SetActive(false);
    }
    
    public void ShowFinalScore()
    {
        DrawNumber(_gameState.Score, _finalScoreContainer);
    }
    public void ShowBestScore()
    {
        DrawNumber(_scoreManager.CurrentBestScore(), _bestScoreContainer);
    }
    public void RefreshAmountOfMoneyCounter()
    {
        DrawNumber(_gameState.AmountOfMoney, _amountOfMoneyContainer);
    }

    public void ShowCurrentScore()
    {
        ShowNumber(_currentScoreContainer);
    }
    public void HideCurrentScore()
    {
        HideNumber(_currentScoreContainer);
    }
    
    public void ShowAmountOfMoney()
    {
        ShowNumber(_amountOfMoneyContainer);
    }
    public void HideAmountOfMoney()
    {
        HideNumber(_amountOfMoneyContainer);
    }
    
    public void RefreshCurrentScoreCounter(int score)
    {
        DrawNumber(score, _currentScoreContainer);
    }

    #endregion
}
