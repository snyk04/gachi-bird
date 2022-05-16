using AreYouFruits.Common.ComponentGeneration;
using GachiBird.UserInterface.MusicList;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMusicPlayerComponent : AbstractComponent<FlexMusicPlayer>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _backgroundMusicAudioPlayer;
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _flexMusicAudioPlayer;
#nullable enable

        protected override FlexMusicPlayer Create()
        {
            return new FlexMusicPlayer(
                _flexModeHandler.GetHeldItem(),
                _backgroundMusicAudioPlayer.GetHeldItem(),
                _flexMusicAudioPlayer.GetHeldItem()
            );
        }
    }
}
