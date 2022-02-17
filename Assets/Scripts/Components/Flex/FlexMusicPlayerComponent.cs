using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexMusicPlayerComponent : AbstractComponent<FlexMusicPlayer>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private AudioSource _backgroundMusicAudioSource;
        [SerializeField] private AudioSource _flexMusicAudioSource;
#nullable enable

        protected override FlexMusicPlayer Create()
        {
            return new FlexMusicPlayer(
                _flexModeHandler.GetHeldItem(),
                _backgroundMusicAudioSource,
                _flexMusicAudioSource
            );
        }
    }
}
