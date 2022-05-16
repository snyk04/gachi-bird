using GachiBird.Environment.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.MusicList
{
    public class MusicListElementComponent : MonoBehaviour, IMusicListElement
    {
#nullable disable
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        [SerializeField] private Image _blockImage;
#nullable enable
        
        private BoosterInfo _boosterInfo;

        public bool IsActive { get; private set; }
        
        public void Setup(BoosterInfo boosterInfo)
        {
            _boosterInfo = boosterInfo;

            _image.sprite = _boosterInfo.Sprite;
            _text.text = "???\n???";
        }

        public void Activate()
        {
            IsActive = true;
            _text.text = $"{_boosterInfo.Author}\n{_boosterInfo.Title}";
            _blockImage.enabled = false;
        }
    }
}