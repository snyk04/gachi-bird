using GachiBird.Game;
using GachiBird.PlayerLogic;
using UnityEngine;

namespace GachiBird.Input
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private Player _player;

        private void Awake()
        {
            SetControls();
            
            _gameCycle.OnGameStart += _player.ResetGravityScale;
            _gameCycle.OnGameEnd += DisableControls;
        }
        
        private void OnEnable()
        {
            EnableControls();
        }
        private void OnDisable()
        {
            DisableControls();
        }
        private void OnDestroy()
        {
            UnsetControls();
        }
        
        private void SetControls()
        {
            GeneralInput.Controls.Player.Jump.performed += _player.Jump;
        }
        private void UnsetControls()
        {
            GeneralInput.Controls.Player.Jump.performed -= _player.Jump;
        }

        private void EnableControls()
        {
            GeneralInput.Controls.Player.Enable();
        }
        private void DisableControls()
        {
            GeneralInput.Controls.Player.Disable();
        }
    }
}
