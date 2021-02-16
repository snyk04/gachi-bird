using UnityEngine.UI;
using UnityEngine;


public class SkinsManager : MonoBehaviour
{
    private GameStateManager gameState;
    private PrefabsManager prefabs;
    private UIManager uI;
    private SerializationManager serialization;
    private DrawNumberManager drawNumber;
    private SpritesManager sprites;
    private ComponentsManager components;

    void Awake()
    {
        gameState = GetComponent<GameStateManager>();
        prefabs = GetComponent<PrefabsManager>();
        uI = GetComponent<UIManager>();
        serialization = GetComponent<SerializationManager>();
        drawNumber = GetComponent<DrawNumberManager>();
        sprites = GetComponent<SpritesManager>();
        components = GetComponent<ComponentsManager>();
    }

    public void BuySkin()
    {
        int pageID = gameState.CurrentShopPageID;
        ShopPage currentShopPage = prefabs.shopPagesArray[pageID].GetComponent<ShopPage>();
        Image skinStatusImage = uI.shopInterface.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<Image>();
        Image skinLookImage = uI.shopInterface.transform.GetChild(4).GetChild(5).GetChild(0).GetComponent<Image>();
        Button selectButton = uI.shopInterface.transform.GetChild(2).GetChild(3).GetComponent<Button>();
        Button buyButton = uI.shopInterface.transform.GetChild(2).GetChild(4).GetComponent<Button>();

        gameState.AmountOfMoney -= currentShopPage.price;
        gameState.StatusOfSkinsDict[pageID] = true;

        serialization.SaveAmountOfMoney(gameState.AmountOfMoney);
        serialization.SaveStatusOfSkins(gameState.StatusOfSkinsDict);

        drawNumber.DrawMoney(gameState.AmountOfMoney, uI.shopMoneyCounterMenu, sprites.smallDigitsDict, sprites.DefaultSpritesArray);
        skinStatusImage.sprite = sprites.ShopArray[12];
        skinLookImage.color = Color.white;

        buyButton.interactable = false;
        selectButton.interactable = true;

        components.audioPlayer.PlaySound(
            components.audioPlayer.yeeaahSound,
            components.audioPlayer.inGameSoundAudioSource,
            1,
            false
            );
    }
    public void SelectSkin()
    {
        int pageID = gameState.CurrentShopPageID;
        Button selectButton = uI.shopInterface.transform.GetChild(2).GetChild(3).GetComponent<Button>();
        Image skinSelectedImage = uI.shopInterface.transform.GetChild(4).GetChild(4).GetChild(0).GetComponent<Image>();

        skinSelectedImage.sprite = sprites.ShopArray[12];
        gameState.SkinID = pageID;
        serialization.SaveSkinID(pageID);
        selectButton.interactable = false;
        components.audioPlayer.PlaySound(
            components.audioPlayer.doYouLikeWhatYouSeeSound,
            components.audioPlayer.inGameSoundAudioSource,
            1,
            false
            );
    }
}
