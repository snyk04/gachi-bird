﻿using AreYouFruits.Common.ComponentGeneration;
using GachiBird.UserInterface.MusicList;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class MusicListWindow : BaseWindow
    {
#nullable disable
        [Header("Objects")] 
        [SerializeField] private Button _closeButton;

        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _musicListMusicAudioPlayer;
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _backgroundMusicAudioPlayer;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnMusicListWindowShow += () =>
            {
                Show();
                _backgroundMusicAudioPlayer.GetHeldItem().Pause();
            };
            _userInterfaceCycle.GetHeldItem().OnMusicListWindowHide += () =>
            {
                Hide();
                _musicListMusicAudioPlayer.GetHeldItem().Stop();
                _backgroundMusicAudioPlayer.GetHeldItem().UnPause();
            };

            _closeButton.onClick.AddListener(() =>
                {
                    _userInterfaceCycle.GetHeldItem().HideMusicListWindow();
                    _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
                }
            );
        }
    }
}