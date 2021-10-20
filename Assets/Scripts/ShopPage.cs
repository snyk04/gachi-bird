using UnityEngine.UI;
using UnityEngine;


public class ShopPage : MonoBehaviour
{
    private GameStateManager gameState;
    private SpritesManager sprites;
    private UIManager uI;
    private DrawNumberManager drawNumber;

    public int iD;
    public int price;
    public bool Status { get; set; }

    void Awake()
    {
        gameState = FindObjectOfType<GameStateManager>();
        sprites = FindObjectOfType<SpritesManager>();
        uI = FindObjectOfType<UIManager>();
        drawNumber = FindObjectOfType<DrawNumberManager>();

        Status = gameState.StatusOfSkinsDict[iD];
    }
    void Start()
    {
        drawNumber.DrawMoney(price, transform.GetChild(2), sprites.priceDigitsDict, sprites.ShopArray);
        ConfigureSprites();
        ConfigureButtons();
    }

    private void ConfigureSprites()
    {
        if (Status) 
        {
            transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = sprites.ShopArray[12];
            transform.GetChild(5).GetChild(0).GetComponent<Image>().color = Color.white;
        } 
        else 
        { 
            transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = sprites.ShopArray[11];
            transform.GetChild(5).GetChild(0).GetComponent<Image>().color = Color.black;
        }

        if (iD == gameState.SkinID) transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = sprites.ShopArray[12];
        else transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = sprites.ShopArray[11];
    }
    private void ConfigureButtons()
    {
        Button buyButton = uI.shopInterface.transform.GetChild(2).GetChild(4).GetComponent<Button>();
        Button selectButton = uI.shopInterface.transform.GetChild(2).GetChild(3).GetComponent<Button>();
        Button leftButton = uI.shopInterface.transform.GetChild(2).GetChild(1).GetComponent<Button>();
        Button rightButton = uI.shopInterface.transform.GetChild(2).GetChild(2).GetComponent<Button>();

        buyButton.interactable = true;
        selectButton.interactable = true;
        leftButton.interactable = true;
        rightButton.interactable = true;

        if (iD == gameState.StatusOfSkinsDict.Count - 1) rightButton.interactable = false;
        else if (iD == 0) leftButton.interactable = false;

        if ((gameState.AmountOfMoney < price) || (Status == true)) buyButton.interactable = false;
        if ((!Status) ||(gameState.SkinID == iD)) selectButton.interactable = false;
    }
}
