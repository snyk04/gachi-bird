using GachiBird.Environment.Objects;
using GachiBird.UserInterface.MusicList;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMusicPlayer
    {
        private readonly IAudioPlayer _backgroundMusicAudioPlayer;
        private readonly IAudioPlayer _flexMusicAudioPlayer;

        public FlexMusicPlayer(IFlexModeHandler flexModeHandler,
            IAudioPlayer backgroundMusicAudioPlayer, IAudioPlayer flexMusicAudioPlayer)
        {
            _backgroundMusicAudioPlayer = backgroundMusicAudioPlayer;
            _flexMusicAudioPlayer = flexMusicAudioPlayer;

            flexModeHandler.OnFlexModeStart += HandleFlexModeStart;
            flexModeHandler.OnFlexModeEnd += HandleFlexModeEnd;
        }

        private void HandleFlexModeStart(BoosterInfo boosterInfo)
        {
            _backgroundMusicAudioPlayer.Pause();
            _flexMusicAudioPlayer.Play(boosterInfo.Music);
        }
        private void HandleFlexModeEnd()
        {
            _flexMusicAudioPlayer.Stop();
            _backgroundMusicAudioPlayer.UnPause();
        }
    }
}