using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using GachiBird.UserInterface.MusicList;
using UnityEngine;

namespace GachiBird.Audio
{
    public class SelectSkinSoundComponent : AbstractComponent<SelectSkinSound>
    {
#nullable disable
        [SerializeField] private SerializedInterface<IComponent<IPlayerCustomizer>> _playerCustomizer;
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _audioPlayer;
#nullable enable
        
        protected override SelectSkinSound Create()
        {
            return new SelectSkinSound(_playerCustomizer.GetHeldItem(), _audioPlayer.GetHeldItem());
        }
    }
}