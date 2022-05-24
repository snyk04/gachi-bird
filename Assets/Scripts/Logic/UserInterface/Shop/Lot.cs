using GachiBird.Customization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class Lot : ILot, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        private readonly Image _backgroundSelection;
        private readonly Image _lockImage;
        private readonly Image _shopImage;
        private readonly Text _priceText;
        private readonly Transform _transform;
        
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
        
        public void Setup(IPlayerCustomizer? playerCustomizer, PlayerSkinInfo playerSkinInfo)
        {
            _playerCustomizer = playerCustomizer;
            _playerSkinInfo = playerSkinInfo;
            
            _shopImage.sprite = _playerSkinInfo.ShopImage;
            _priceText.text = _playerSkinInfo.Price.ToString();
            
            SetSelect(_playerCustomizer!.IsSkinSelected(playerSkinInfo.Id));
            SetLock(_playerCustomizer!.IsSkinLocked(playerSkinInfo.Id));

            playerCustomizer!.OnPlayerSkinSelect += selectedSkinInfo => HandlePlayerSkinSelect(selectedSkinInfo.Id);
            playerCustomizer!.OnPlayerSkinPurchase += purchasedSkinInfo => HandlePlayerSkinPurchase(purchasedSkinInfo.Id);
        }

        private void HandlePlayerSkinSelect(int skinId)
        {
            SetSelect(skinId == _playerSkinInfo.Id);
        }
        private void HandlePlayerSkinPurchase(int skinId)
        {
            if (skinId == _playerSkinInfo.Id)
            {
                SetLock(false);
            }
        }

        private void SetSelect(bool isSelected)
        {
            _backgroundSelection.enabled = isSelected;
        }
        private void SetLock(bool isLocked)
        {
            _lockImage.enabled = isLocked;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _transform.localScale = 0.95f * Vector3.one;
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            _transform.localScale = Vector3.one;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _playerCustomizer!.TryToChangeSkin(_playerSkinInfo);
        }
    }
}