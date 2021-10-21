using UnityEngine;

namespace UserInterface
{
    public sealed class PreStartInterface : MonoBehaviour
    {
        #region References

        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;

        #endregion

        #region Objects

        [Header("Objects")] 
        [SerializeField] private GameObject _interfaceContainer;

        #endregion

        #region MonoBehaviour methods

        private void Awake()
        {
            _gameCycle.OnGameStart += HideInterface;
        }

        #endregion

        #region Methods

        private void HideInterface()
        {
            _interfaceContainer.SetActive(false);
        }

        #endregion
    }
}
