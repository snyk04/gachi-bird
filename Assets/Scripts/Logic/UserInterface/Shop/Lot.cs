using System;
using System.Collections.Generic;
using Components.Customization;
using GachiBird.Customization;
using GachiBird.Game;
using GachiBird.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class Lot : ILot, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<ILot>? OnSelect;

        private readonly Image _backgroundSelection;
        private readonly Image _lockImage;
        private readonly Image _shopImage;
        private readonly Text _priceText;
        private readonly Transform _transform;
        
        private IGameSaver? _gameSaver;
        private IMoneyHolder? _moneyHolder;
        private IPlayerCustomizer? _playerCustomizer;
        private PlayerSkinInfo _playerSkinInfo;

        public Lot(Image backgroundSelection, Image lockImage, Image shopImage, Text priceText, Transform transform)
        {
            _backgroundSelection = backgroundSelection;
            _lockImage = lockImage;
            _shopImage = shopImage;
            _priceText = priceText;
            _transform = transform;
        }
        
        public void Setup(IGameSaver? gameSaver, IMoneyHolder? moneyHolder, IPlayerCustomizer? playerCustomizer,
            PlayerSkinInfo playerSkinInfo)
        {
            _gameSaver = gameSaver;
            _moneyHolder = moneyHolder;
            _playerCustomizer = playerCustomizer;
            _playerSkinInfo = playerSkinInfo;
            
            _shopImage.sprite = _playerSkinInfo.ShopImage;
            _priceText.text = _playerSkinInfo.Price.ToString();
        }
        
        public void SetSelect(bool isSelected)
        {
            _backgroundSelection.enabled = isSelected;
        }
        public void SetLock(bool isLocked)
        {
            _lockImage.enabled = isLocked;
        }

        private void HandleClick()
        {
            if (IsLotAlreadyChosen())
            {
                return;
            }

            if (TryToSelectSkin())
            {
                return;
            }

            TryToBuySkin();
        }

        private bool IsLotAlreadyChosen()
        {
            return _gameSaver!.LoadCurrentSkinId() == _playerSkinInfo.Id;
        }
        private bool TryToSelectSkin()
        {
            if (_gameSaver.LoadStatusOfSkins()[_playerSkinInfo.Id])
            {
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
                SetSelect(true);
                OnSelect?.Invoke(this);
                return true;
            }

            return false;
        }
        private bool TryToBuySkin()
        {
            if (_moneyHolder!.Money >= _playerSkinInfo.Price)
            {
                Dictionary<int, bool> statusOfSkins = _gameSaver!.LoadStatusOfSkins();
                statusOfSkins[_playerSkinInfo.Id] = true;
                _gameSaver!.SaveStatusOfSkins(statusOfSkins);
                _moneyHolder!.Money -= _playerSkinInfo.Price;
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
                
                SetSelect(true);
                SetLock(false);
                OnSelect?.Invoke(this);
                
                return true;
            }

            return false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _transform.localScale = 0.95f * Vector3.one;
            HandleClick();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            _transform.localScale = Vector3.one;
        }
    }
}