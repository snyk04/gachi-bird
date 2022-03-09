using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Windows
{
    public sealed class SetUserNameWindow : BaseWindow
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;

        [Header("Buttons")] 
        [SerializeField] private Button _submitButton;

        [Header("Objects")] 
        [SerializeField] private InputField _userNameInputField;
#nullable enable

        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnSetUserNameWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnSetUserNameWindowHide += Hide;
            
            _submitButton.onClick.AddListener(HandleSubmitButtonClick);
        }

        private void HandleSubmitButtonClick()
        {
            _userInterfaceCycle.GetHeldItem().HideSetUserNameWindow();
            _userInterfaceCycle.GetHeldItem().ShowPreStartWindow();

            _gameSaver.GetHeldItem().SaveUserName(_userNameInputField.text);
        }
    }
}