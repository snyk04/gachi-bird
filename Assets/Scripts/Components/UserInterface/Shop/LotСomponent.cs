using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class LotСomponent : AbstractComponent<Lot>, IPointerDownHandler, IPointerUpHandler
    {
#nullable disable
        [Header("Objects")] 
        [SerializeField] private Image _backgroundSelection;
        [SerializeField] private Image _lockImage;
        [SerializeField] private Image _image;
        [SerializeField] private Text _priceText;
#nullable enable
        
        protected override Lot Create()
        {
            return new Lot(_backgroundSelection, _lockImage, _image, _priceText, transform);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            HeldItem.OnPointerUp(eventData);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            HeldItem.OnPointerDown(eventData);
        }
    }
}