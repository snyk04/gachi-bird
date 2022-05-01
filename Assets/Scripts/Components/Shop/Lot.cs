using System.Collections.Generic;
using Components.Customization;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachiBird.Shop
{
    public class Lot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
#nullable disable
        [Header("Objects")] 
        [SerializeField] private Image _image;
        [SerializeField] private Text _priceText;
#nullable enable

        private IGameSaver? _gameSaver;
        private IMoneyHolder? _moneyHolder;
        private IPlayerCustomizer? _playerCustomizer;

        private PlayerSkinInfo _playerSkinInfo;

        public void Setup(IGameSaver gameSaver, IMoneyHolder moneyHolder, IPlayerCustomizer playerCustomizer,
            PlayerSkinInfo playerSkinInfo)
        {
            _gameSaver = gameSaver;
            _moneyHolder = moneyHolder;
            _playerCustomizer = playerCustomizer;

            _playerSkinInfo = playerSkinInfo;

            _image.sprite = _playerSkinInfo.ShopPage;
            _priceText.text = _playerSkinInfo.Price.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Shrink();
            HandleClick();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            Unshrink();
        }

        private void Shrink()
        {
            transform.localScale = 0.95f * Vector3.one;
        }
        private void Unshrink()
        {
            transform.localScale = Vector3.one;
        }

        private void HandleClick()
        {
            if (_gameSaver!.LoadCurrentSkinId() == _playerSkinInfo.Id)
            {
                // If this skin is already selected - ignore click
                return;
            }

            if (!_gameSaver!.LoadStatusOfSkins().ContainsKey(_playerSkinInfo.Id))
            {
                // TODO : Maybe move stuff like that to specified class
                
                Dictionary<int, bool> statusOfSkins = _gameSaver!.LoadStatusOfSkins();
                statusOfSkins.Add(_playerSkinInfo.Id, false);
            }

            if (_gameSaver.LoadStatusOfSkins()[_playerSkinInfo.Id])
            {
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
                return;
            }

            if (_moneyHolder!.Money >= _playerSkinInfo.Price)
            {
                Dictionary<int, bool> statusOfSkins = _gameSaver!.LoadStatusOfSkins();
                statusOfSkins[_playerSkinInfo.Id] = true;
                _gameSaver!.SaveStatusOfSkins(statusOfSkins);
                _moneyHolder.Money -= _playerSkinInfo.Price;
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
            }
        }
    }
}