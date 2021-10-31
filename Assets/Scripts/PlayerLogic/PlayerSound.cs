using GachiBird.Game;
using UnityEngine;
using GachiBird.UserInterface;
using UnityEngine.Serialization;

namespace GachiBird.PlayerLogic
{
    public sealed class PlayerSound : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private Player _player;
        [SerializeField] private ScoreManager _scoreManager;
        
        [Header("Audio sources")]
        [SerializeField] private AudioSource _checkpointAudioSource;
        [SerializeField] private AudioSource _deathAudioSource;
        [SerializeField] private AudioSource _jumpAudioSource;

        private void Awake()
        {
            _scoreManager.PointGet += _checkpointAudioSource.Play;
            _gameCycle.OnGameEnd += _deathAudioSource.Play;
            _player.OnJump += _jumpAudioSource.Play;
        }
    }
}
