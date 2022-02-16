using AreYouFruits.Common.ComponentGeneration;
using GachiBird.CameraMovement;
using GachiBird.Environment;
using GachiBird.Flex.Visual;
using GachiBird.Game;
using UnityEngine;

namespace GachiBird.Flex
{
    public sealed class FlexModeHandlerComponent : DestroyableAbstractComponent<IFlexModeHandler>
    {
#nullable disable
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private AbstractComponent<IControllableCameraEffect>[] _cameraEffects;
        [SerializeField] private AbstractComponent<IBoosterSpawner> _boosterSpawner;
        [SerializeField] private AbstractComponent<IGameCycle> _gameCycle;
        [SerializeField] private AudioSource _backgroundMusicAudioSource;
        [SerializeField] private AudioSource _flexMusicAudioSource;
        [SerializeField] private PostFXFeature _flexRenderFeature;
#nullable enable

        protected override IFlexModeHandler Create()
        {
            return new FlexModeHandler(
                _player,
                _cameraEffects.ExtractAsArray(),
                _boosterSpawner.HeldItem,
                _gameCycle.HeldItem,
                _backgroundMusicAudioSource,
                _flexMusicAudioSource,
                _flexRenderFeature
            );
        }
    }
}
