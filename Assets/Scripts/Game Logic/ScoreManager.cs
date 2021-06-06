using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private SerializationManager serializationManager;
    private GameStateManager gameState;
    private UIManager uI;
    private DrawNumberManager drawNumber;
    private SpritesManager sprites;

    private void Awake()
    {
        serializationManager = SerializationManager.Instance;
        gameState = GetComponent<GameStateManager>();
        uI = GetComponent<UIManager>();
        drawNumber = GetComponent<DrawNumberManager>();
        sprites = GetComponent<SpritesManager>();
    }

    public int CurrentBestScoreForDrawing()
    {
        int bestScore;
        int loadedBestScore = serializationManager.LoadBestScore();
        if ((loadedBestScore == -1) || (gameState.Score > loadedBestScore)) {
            bestScore = gameState.Score;
            serializationManager.SaveBestScore(gameState.Score);
        } else {
            bestScore = loadedBestScore;
        }
        return bestScore;
    }
    public int CurrentBestScoreForNextImage()
    {
        int bestScore;
        int loadedBestScore = serializationManager.LoadBestScore();
        if ((loadedBestScore == -1)) {
            bestScore = gameState.Score;
        } else {
            bestScore = loadedBestScore;
        }
        return bestScore;
    }
    public void RefreshScoreCounter()
    {
        uI.scoreMenu.transform.GetChild(0).GetComponent<Image>().SetNativeSize();
        uI.scoreMenu.transform.GetChild(1).GetComponent<Image>().SetNativeSize();
        uI.scoreMenu.transform.GetChild(2).GetComponent<Image>().SetNativeSize();

        float digitWidth = 120f;
        float yCoord = uI.scoreMenu.transform.GetChild(0).GetComponent<RectTransform>().localPosition.y;

        if (gameState.Score.ToString().Length == 1) {
            uI.scoreMenu.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(0, yCoord);
        } else if (gameState.Score.ToString().Length == 2) {
            uI.scoreMenu.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(digitWidth / 2.6f, yCoord);
            uI.scoreMenu.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector2(-digitWidth / 2.6f, yCoord);
        } else if (gameState.Score.ToString().Length == 3) {
            uI.scoreMenu.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(digitWidth / 1.3f, yCoord);
            uI.scoreMenu.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector2(0, yCoord);
            uI.scoreMenu.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector2(-digitWidth / 1.3f, yCoord);
        }
        drawNumber.DrawScore(gameState.Score, uI.scoreMenu.transform, sprites.bigDigitsDict, sprites.DefaultSpritesArray);
    }
}
