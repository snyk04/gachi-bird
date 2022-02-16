using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using UnityEngine;
using GachiBird.UserWindows;

namespace GachiBird.PlayerLogic
{
    public sealed class GameSounds : MonoBehaviour
    {
#nullable disable
        [Header("References")]
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AbstractComponent<IJumpable> _player;
        [SerializeField] private AbstractComponent<IScoreHolder> _scoreHolder;
        
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
