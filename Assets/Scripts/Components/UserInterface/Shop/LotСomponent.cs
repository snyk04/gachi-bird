using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class LotСomponent : AbstractComponent<Lot>, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
#nullable disable
        [SerializeField] private Image _backgroundSelection;
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _shopImage;
        [SerializeField] private Text _priceText;
#nullable enable
        
        protected override Lot Create()
        {
            return new Lot(_backgroundSelection, _lockImage, _shopImage, _priceText, transform);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            HeldItem.OnPointerUp(eventData);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            HeldItem.OnPointerDown(eventData);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            HeldItem.OnPointerClick(eventData);
        } 
    }
}