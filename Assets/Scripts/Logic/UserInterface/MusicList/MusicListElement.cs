using GachiBird.Environment.Objects;
using UnityEngine.UI;

namespace GachiBird.UserInterface.MusicList
{
    public class MusicListElement : IMusicListElement
    {
        private readonly Image _image;
        private readonly Text _text;
        private readonly Image _blockImage;
        private readonly Button _playMusicButton;
        private readonly AspectRatioFitter _aspectRatioFitter;

        private BoosterInfo _boosterInfo;
        
        public bool IsActive { get; private set; }

        public MusicListElement(Image image, Text text, Image blockImage, Button playMusicButton, 
            AspectRatioFitter aspectRatioFitter)
        {
            _image = image;
            _text = text;
            _blockImage = blockImage;
            _playMusicButton = playMusicButton;
            _aspectRatioFitter = aspectRatioFitter;
        }

        public void Setup(BoosterInfo boosterInfo, IAudioPlayer audioPlayer)
        {
            _boosterInfo = boosterInfo;

            _image.sprite = _boosterInfo.Sprite;
            _aspectRatioFitter.aspectRatio = _boosterInfo.Sprite.rect.width / _boosterInfo.Sprite.rect.height;
            _text.text = "???\n???";
            
            _playMusicButton.onClick.AddListener(() =>
            {
                audioPlayer.Play(_boosterInfo.Music);
            });
        }
        public void Activate()
        {
            IsActive = true;
            _text.text = $"{_boosterInfo.Author}\n{_boosterInfo.Title}";
            _blockImage.enabled = false;
            _playMusicButton.interactable = true;
        }
    }
}