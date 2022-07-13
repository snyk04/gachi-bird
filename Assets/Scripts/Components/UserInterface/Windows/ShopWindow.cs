using System;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public class ShopWindow : BaseWindow
    {
    #nullable disable
        // TODO : Make it "back" button, which will return player to previous window (pre start or game over)
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IMoneyHolder>> _moneyHolder;

        [Header("Objects")]
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _moneyCounter;
    #nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType =>
            {
                if (windowType == WindowType.Shop)
                {
                    Show();
                }
            };

            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType =>
            {
                if (windowType == WindowType.Shop)
                {
                    Hide();
                }
            };

            _closeButton.onClick.AddListener(
                (() =>
                {
                    _userInterfaceCycle.GetHeldItem().HideWindow(WindowType.Shop);
                    _userInterfaceCycle.GetHeldItem().ShowWindow(WindowType.GameOver);
                })
            );

            _moneyHolder.GetHeldItem().OnMoneyChanged += RefreshMoneyCounter;
        }

        private void Start()
        {
            RefreshMoneyCounter();
        }

        private void RefreshMoneyCounter()
        {
            _moneyCounter.text = _moneyHolder.GetHeldItem().Money.ToString();
        }
    }
}
