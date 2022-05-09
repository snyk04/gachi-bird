using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace GachiBird.UserInterface.Shop
{
    public class ApproverComponent : AbstractComponent<Approver>
    {
#nullable disable
        [SerializeField] private GameObject _approveWindow;
        [SerializeField] private Button _approveButton;
        [SerializeField] private Button _disapproveButton;
        [SerializeField] private Image _image;
        [SerializeField] private Text _approveButtonText;
#nullable enable
        
        protected override Approver Create()
        {
            return new Approver(_approveWindow, _approveButton, _disapproveButton, _image, _approveButtonText);
        }
    }
}