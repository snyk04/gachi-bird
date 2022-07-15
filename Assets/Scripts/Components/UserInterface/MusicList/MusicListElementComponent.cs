using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.MusicList
{
    public class MusicListElementComponent : AbstractComponent<MusicListElement>
    {
#nullable disable
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        [SerializeField] private Image _blockImage;
        [SerializeField] private Button _playMusicButton;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;
#nullable enable
        
        protected override MusicListElement Create()
        {
            return new MusicListElement(_image, _text, _blockImage, _playMusicButton, _aspectRatioFitter);
        }
    }
}