using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GachiBird.Game
{
    public sealed class GameFirstInputStarter
    {
        private readonly InputAction _playerJumpAction;

        public GameFirstInputStarter(IGameCycle gameCycle)
        {
            // TODO : Start game after username is set
            
            _playerJumpAction = new Controls().Player.Jump;

            _playerJumpAction.performed += StartGame;
            _playerJumpAction.Enable();

            void StartGame(InputAction.CallbackContext context)
            {
                _playerJumpAction.performed -= StartGame;
                _playerJumpAction.Disable();

                gameCycle.StartGame();
            }
        }
    }
}
