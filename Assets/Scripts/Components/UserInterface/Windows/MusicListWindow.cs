using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class MusicListWindow : BaseWindow
    {
#nullable disable
        [Header("Objects")] [SerializeField] private Button _closeButton;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnMusicListWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnMusicListWindowHide += Hide;

            _closeButton.onClick.AddListener(() =>
                {
                    _userInterfaceCycle.GetHeldItem().HideMusicListWindow();
                    _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
                }
            );
        }
    }
}