using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class ShopWindow : BaseWindow
    {
#nullable disable
        // TODO : Make it "back" button, which will return player to previous window (pre start or game over)
        [Header("Buttons")] 
        [SerializeField] private Button _closeButton;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnShopWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnShopWindowHide += Hide;

            _closeButton.onClick.AddListener((() =>
                {
                    _userInterfaceCycle.GetHeldItem().HideShopWindow();
                    _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
                })
            );
        }
    }
}