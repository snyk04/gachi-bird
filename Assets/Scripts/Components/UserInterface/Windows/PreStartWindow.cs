using AreYouFruits.Common.ComponentGeneration;

namespace GachiBird.UserInterface.Windows
{
    public sealed class PreStartWindow : BaseWindow
    {
        private void Awake()
        {
            _userInterfaceCycle.GetHeldItem().OnWindowShow += windowType => 
            {
                if (windowType == WindowType.PreStart)
                {
                    Show();
                }
            };
            
            _userInterfaceCycle.GetHeldItem().OnWindowHide += windowType => 
            {
                if (windowType == WindowType.PreStart)
                {
                    Hide();
                }
            };
        }
    }
}