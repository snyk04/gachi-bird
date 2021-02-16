using UnityEngine.UI;
using UnityEngine;


public class MusicListManager : MonoBehaviour
{
    private UIManager uI;
    private GameStateManager gameState;
    private SpritesManager sprites;

    void Awake()
    {
        uI = GetComponent<UIManager>();
        gameState = GetComponent<GameStateManager>();
        sprites = GetComponent<SpritesManager>();
    }

    public void ConfigureSpritesAndButtons()
    {
        for (int i = 0; i < gameState.StatusOfMusicDict.Count; i++)
        {
            if (gameState.StatusOfMusicDict[i])
            {
                uI.musicListInterface.transform.GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(false);
                uI.musicListInterface.transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().sprite = sprites.musicTracksSpritesArray[i];
                uI.musicListInterface.transform.GetChild(0).GetChild(3).GetChild(i).GetComponent<Button>().interactable = true;

            }
            else
            {
                uI.musicListInterface.transform.GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
                uI.musicListInterface.transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<Image>().sprite = sprites.unnamedTrackSprite;
                uI.musicListInterface.transform.GetChild(0).GetChild(3).GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }
}
