using System;
using GachiBird.Environment.Colliders;
using GachiBird.PlayerLogic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GachiBird.Game
{
    public sealed class GameCycle : MonoBehaviour
    {
        [SerializeField] private PlayerBordersTriggerComponent _playerBordersTrigger;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Collider2DListener _playerColliderListener;
        
        public event Action OnGameStart;
        public event Action OnGameEnd;

        private InputAction _playerJumpAction;
    
        private void Awake()
        {
            _playerJumpAction = new Controls().Player.Jump;
            
            _playerJumpAction.performed += StartGame;
            _playerJumpAction.Enable();
            
            _playerBordersTrigger.HeldItem.OnPlayerOutOfBounds += EndGame;
            _playerColliderListener.OnCollide += (_, __) => EndGame();
        }
    
        private void StartGame(InputAction.CallbackContext context)
        {
            _playerJumpAction.performed -= StartGame;
            _playerJumpAction.Disable();
            
            OnGameStart?.Invoke();
        }
        
        private void EndGame()
        {
            OnGameEnd?.Invoke();
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
