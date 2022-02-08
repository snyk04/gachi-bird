#nullable enable

using GachiBird.Game;
using UnityEngine;
using GachiBird.UserWindows;

namespace GachiBird.PlayerLogic
{
    public sealed class GameSounds : MonoBehaviour
    {
#nullable disable
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private PlayerComponent _player;
        [SerializeField] private ScoreHolderComponent _scoreHolder;
        
        [Header("Audio sources")]
        [SerializeField] private AudioSource _checkpointAudioSource;
        [SerializeField] private AudioSource _deathAudioSource;
        [SerializeField] private AudioSource _jumpAudioSource;
#nullable enable
        
        private void Awake()
        {
            _scoreHolder.HeldItem.OnScoreChanged += _checkpointAudioSource.Play;
            _gameCycle.HeldItem.OnGameEnd += _deathAudioSource.Play;
            _player.HeldItem.OnJump += _jumpAudioSource.Play;
        }
    }
}
