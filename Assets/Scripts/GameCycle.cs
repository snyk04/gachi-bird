using System;
using InputHandling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public sealed class GameCycle : MonoBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    
    private void Awake()
    {
        GeneralInput.Controls.Player.Jump.performed += StartGame;
    }
    
    private void StartGame(InputAction.CallbackContext context)
    {
        GeneralInput.Controls.Player.Jump.performed -= StartGame;
        OnGameStart?.Invoke();
    }
    public void EndGame()
    {
        OnGameEnd?.Invoke();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
