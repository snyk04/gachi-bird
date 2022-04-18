using Components.Customization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Components.Shop
{
    public class Lot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
#nullable disable
        [SerializeField] private Image _image;
        [SerializeField] private Text _priceText;
#nullable enable
        
        public void Setup(PlayerSkinInfo playerSkinInfo)
        {
            _image.sprite = playerSkinInfo.ShopPage;
            _priceText.text = playerSkinInfo.Price.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Shrink();
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
    }
}