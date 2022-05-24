using System;
using GachiBird.Customization;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class Approver : IApprover
    {
        private readonly GameObject _approveWindow;
        private readonly Image _image;
        private readonly Text _approveButtonText;

        public Approver(GameObject approveWindow, Button approveButton, Button disapproveButton, Image image, 
            Text approveButtonText)
        {
            _approveWindow = approveWindow;
            _image = image;
            _approveButtonText = approveButtonText;

            approveButton.onClick.AddListener(Approve);
            disapproveButton.onClick.AddListener(Disapprove);
        }

        public event Action? OnApproval;
        public void CallForApproval(PlayerSkinInfo playerSkinInfo)
        {
            _approveWindow.SetActive(true);

            _image.sprite = playerSkinInfo.ShopImage;
            _approveButtonText.text = playerSkinInfo.Price.ToString();
        }

        private void Approve()
        {
            OnApproval?.Invoke();
            OnApproval = null;
            _approveWindow.SetActive(false);
        }
        private void Disapprove()
        {
            _approveWindow.SetActive(false);
        }
    }
}