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
            _userInterfaceCycle.GetHeldItem().OnShopWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnShopWindowHide += Hide;

            _closeButton.onClick.AddListener((() =>
                {
                    _userInterfaceCycle.GetHeldItem().HideShopWindow();
                    _userInterfaceCycle.GetHeldItem().ShowGameOverWindow();
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