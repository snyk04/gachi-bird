using UnityEngine;

namespace GachiBird.UserInterface
{
    public abstract class GameInterface : MonoBehaviour
    {
        [Header("Interface components")]
        [SerializeField] private GameObject _container;

        protected void Show()
        {
            ChangeActiveness(true);
        }
        protected void Hide()
        {
            ChangeActiveness(false);
        }

        private void ChangeActiveness(bool isActive)
        {
            _container.SetActive(isActive);
        }
    }
}
