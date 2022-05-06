﻿using System;
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
        private readonly Image _image;
        private readonly Text _priceText;
        private readonly Transform _transform;
        
        private IGameSaver? _gameSaver;
        private IMoneyHolder? _moneyHolder;
        private IPlayerCustomizer? _playerCustomizer;
        private PlayerSkinInfo _playerSkinInfo;

        public Lot(Image backgroundSelection, Image lockImage, Image image, Text priceText, Transform transform)
        {
            _backgroundSelection = backgroundSelection;
            _lockImage = lockImage;
            _image = image;
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
            
            _image.sprite = _playerSkinInfo.ShopPage;
            _priceText.text = _playerSkinInfo.Price.ToString();
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

        public void Select()
        {
            _backgroundSelection.enabled = true;
        }
        public void Deselect()
        {
            _backgroundSelection.enabled = false;
        }

        public void Lock()
        {
            _lockImage.enabled = true;
        }
        public void Unlock()
        {
            _lockImage.enabled = false;
        }

        private void HandleClick()
        {
            if (_gameSaver!.LoadCurrentSkinId() == _playerSkinInfo.Id)
            {
                return;
            }

            if (!_gameSaver!.LoadStatusOfSkins().ContainsKey(_playerSkinInfo.Id))
            {
                // TODO : Maybe move stuff like that to specified class
                
                Dictionary<int, bool> statusOfSkins = _gameSaver!.LoadStatusOfSkins();
                statusOfSkins.Add(_playerSkinInfo.Id, false);
                _gameSaver.SaveStatusOfSkins(statusOfSkins);
            }

            if (_gameSaver.LoadStatusOfSkins()[_playerSkinInfo.Id])
            {
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
                Select();
                OnSelect?.Invoke(this);
                return;
            }

            if (_moneyHolder!.Money >= _playerSkinInfo.Price)
            {
                Dictionary<int, bool> statusOfSkins = _gameSaver!.LoadStatusOfSkins();
                statusOfSkins[_playerSkinInfo.Id] = true;
                _gameSaver!.SaveStatusOfSkins(statusOfSkins);
                _moneyHolder!.Money -= _playerSkinInfo.Price;
                _playerCustomizer!.ChangePlayerSkin(_playerSkinInfo.Id);
                
                Select();
                Unlock();
                OnSelect?.Invoke(this);
            }
        }
    }
}