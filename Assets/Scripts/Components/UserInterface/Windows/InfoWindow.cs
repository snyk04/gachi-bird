using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class InfoWindow : BaseWindow
    {
#nullable disable
        [SerializeField] private Button _closeButton;
#nullable enable
        
        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.Info)
                {
                    Show();
                }
            };

            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.Info)
                {
                    Hide();
                }
            };

            _closeButton.onClick.AddListener(() => 
                {
                    _userInterfaceCycle.GetHeldItem().HideWindow(WindowType.Info);
                    _userInterfaceCycle.GetHeldItem().ShowWindow(WindowType.GameOver);
                }
            );
        }
    }
}