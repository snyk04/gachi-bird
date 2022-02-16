using UnityEngine;

namespace GachiBird.UserWindows
{
    public abstract class BaseWindow : MonoBehaviour
    {
#nullable disable
        [Header("Interface components")]
        [SerializeField] private GameObject _container;
#nullable enable
        
        protected void Show() => _container.SetActive(true);
        protected void Hide() => _container.SetActive(false);
    }
}
