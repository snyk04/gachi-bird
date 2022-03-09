using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.UserInterface.Windows
{
    public abstract class BaseWindow : MonoBehaviour
    {
#nullable disable
        [Header("Interface components")] 
        [SerializeField] protected SerializedInterface<IComponent<IUserInterfaceCycle>> _userInterfaceCycle;
        [SerializeField] private GameObject _container;
#nullable enable
        
        public virtual void Show() => _container.SetActive(true);
        public virtual void Hide() => _container.SetActive(false);
    }
}
