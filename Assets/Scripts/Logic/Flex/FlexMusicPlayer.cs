using GachiBird.Environment.Objects;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMusicPlayer
    {
        private readonly AudioSource _backgroundMusicAudioSource;
        private readonly AudioSource _flexMusicAudioSource;

        public FlexMusicPlayer(IFlexModeHandler flexModeHandler,
            AudioSource backgroundMusicAudioSource, AudioSource flexMusicAudioSource)
        {
            _backgroundMusicAudioSource = backgroundMusicAudioSource;
            _flexMusicAudioSource = flexMusicAudioSource;

            flexModeHandler.OnFlexModeStart += HandleFlexModeStart;
            flexModeHandler.OnFlexModeEnd += HandleFlexModeEnd;
        }

        private void HandleFlexModeStart(BoosterInfo boosterInfo)
        {
            _backgroundMusicAudioSource.Pause();
            _flexMusicAudioSource.clip = boosterInfo.Music;
            _flexMusicAudioSource.Play();
        }
        private void HandleFlexModeEnd()
        {
            _flexMusicAudioSource.Stop();
            _backgroundMusicAudioSource.UnPause();
        }
    }
}