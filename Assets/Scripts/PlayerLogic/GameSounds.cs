using GachiBird.Game;
using UnityEngine;
using GachiBird.UserWindows;

namespace GachiBird.PlayerLogic
{
    public sealed class GameSounds : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private PlayerComponent _player;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
        [Header("Audio sources")]
        [SerializeField] private AudioSource _checkpointAudioSource;
        [SerializeField] private AudioSource _deathAudioSource;
        [SerializeField] private AudioSource _jumpAudioSource;

        private void Awake()
        {
             _scoreHolder.HeldItem.OnScoreChanged += _checkpointAudioSource.Play;
            _gameCycle.OnGameEnd += _deathAudioSource.Play;
            _player.HeldItem.OnJump += _jumpAudioSource.Play;
        }
    }
}
