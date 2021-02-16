using UnityEngine;

public class ChangeShopPageButton : MonoBehaviour
{
    private GameLogic gameLogic;
    private GameStateManager gameState;
    private ComponentsManager components;

    public int type;    // 0 - left, 1 - right

    void Awake()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        gameState = FindObjectOfType<GameStateManager>();
        components = FindObjectOfType<ComponentsManager>();
    }

    public void GoToNextPage()
    {
        gameState.CurrentShopPageID += 1;
        gameLogic.OpenShopPage(gameState.CurrentShopPageID);
    }
    public void GoToPreviousPage()
    {
        gameState.CurrentShopPageID -= 1;
        gameLogic.OpenShopPage(gameState.CurrentShopPageID);
    }
}
