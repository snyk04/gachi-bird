using UnityEngine;

namespace UserInterface
{
    public sealed class PreStartInterface : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private GameCycle _gameCycle;
        
        [Header("Objects")] 
        [SerializeField] private GameObject _interfaceContainer;
        
        private void Awake()
        {
            _gameCycle.OnGameStart += HideInterface;
        }
        
        private void HideInterface()
        {
            _interfaceContainer.SetActive(false);
        }
    }
}
