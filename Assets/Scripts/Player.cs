using UnityEngine;


public class Player : MonoBehaviour
{    
    private GameLogic gameLogic;
    private GameStateManager gameState;
    private ComponentsManager components;

    void Awake()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        gameState = FindObjectOfType<GameStateManager>();
        components = FindObjectOfType<ComponentsManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameState.IsGameStopped) gameLogic.StopGame();
        if (collision.collider.name.ToCharArray()[0] == 'G') components.playerRigidbody.simulated = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.transform.name.ToCharArray()[0] == 'G') || (collision.transform.name == "Ceiling"))
        {
            gameLogic.StopGame();
            if (collision.transform.name.ToCharArray()[0] == 'G')
            {
                components.playerRigidbody.simulated = false;
            }
        }
    }
}
