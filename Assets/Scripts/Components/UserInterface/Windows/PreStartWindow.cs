using AreYouFruits.Common.ComponentGeneration;

namespace GachiBird.UserInterface.Windows
{
    public sealed class PreStartWindow : BaseWindow
    {
        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnPreStartWindowShow += Show;
            _userInterfaceCycle.GetHeldItem().OnPreStartWindowHide += Hide;
        }
    }
}