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
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IJumpable>> _player;
        [SerializeField] private SerializedInterface<IComponent<IScoreHolder>> _scoreHolder;
        
        [Header("Audio sources")]
        [SerializeField] private AudioSource _checkpointAudioSource;
        [SerializeField] private AudioSource _deathAudioSource;
        [SerializeField] private AudioSource _jumpAudioSource;
#nullable enable
        
        private void Awake()
        {
            _scoreHolder.GetHeldItem().OnScoreChanged += _checkpointAudioSource.Play;
            _gameCycle.GetHeldItem().OnGameEnd += _deathAudioSource.Play;
            _player.GetHeldItem().OnJump += _jumpAudioSource.Play;
        }
    }
}
