using UnityEngine;

namespace GachiBird.UserWindows
{
    public abstract class BaseWindow : MonoBehaviour
    {
        [Header("Interface components")]
        [SerializeField] private GameObject _container;

        protected void Show()
        {
            _container.SetActive(true);
        }
        
        protected void Hide()
        {
            _container.SetActive(false);
        }
    }
}
