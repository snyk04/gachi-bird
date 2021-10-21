using System;
using InputHandling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public sealed class GameCycle : MonoBehaviour
{
    #region Events

    public event Action OnGameStart;
    public event Action OnGameEnd;

    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        GeneralInput.Controls.Player.Jump.performed += StartGame;
    }

    #endregion

    #region Methods

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

    #endregion
}
