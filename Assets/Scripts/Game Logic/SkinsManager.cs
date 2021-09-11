using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    #region Properties

    private GameStateManager gameState;
    private PrefabsManager prefabs;
    private UIManager uI;
    private SerializationManager serializationManager;
    private NumberPainter numberPainter;
    private SpritesManager sprites;
    private ComponentsManager components;

    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        gameState = GetComponent<GameStateManager>();
        prefabs = GetComponent<PrefabsManager>();
        uI = GetComponent<UIManager>();
        serializationManager = SerializationManager.Instance;
        numberPainter = GetComponent<NumberPainter>();
        sprites = GetComponent<SpritesManager>();
        components = GetComponent<ComponentsManager>();
    }

    #endregion

    #region Methods

    public void BuySkin()
    {
        var pageID = gameState.CurrentShopPageID;
        var currentShopPage = prefabs.shopPagesArray[pageID].GetComponent<ShopPage>();
        var skinStatusImage = uI.shopInterface.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<Image>();
        var skinLookImage = uI.shopInterface.transform.GetChild(4).GetChild(5).GetChild(0).GetComponent<Image>();
        var selectButton = uI.shopInterface.transform.GetChild(2).GetChild(3).GetComponent<Button>();
        var buyButton = uI.shopInterface.transform.GetChild(2).GetChild(4).GetComponent<Button>();

        gameState.AmountOfMoney -= currentShopPage.price;
        gameState.StatusOfSkinsDict[pageID] = true;

        serializationManager.SaveAmountOfMoney(gameState.AmountOfMoney);
        serializationManager.SaveStatusOfSkins(gameState.StatusOfSkinsDict);

        numberPainter.RefreshAmountOfMoneyCounter();
        
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
        var pageID = gameState.CurrentShopPageID;
        var selectButton = uI.shopInterface.transform.GetChild(2).GetChild(3).GetComponent<Button>();
        var skinSelectedImage = uI.shopInterface.transform.GetChild(4).GetChild(4).GetChild(0).GetComponent<Image>();

        skinSelectedImage.sprite = sprites.ShopArray[12];
        gameState.SkinID = pageID;
        serializationManager.SaveSkinID(pageID);
        selectButton.interactable = false;
        components.audioPlayer.PlaySound(
            components.audioPlayer.doYouLikeWhatYouSeeSound,
            components.audioPlayer.inGameSoundAudioSource,
            1,
            false
        );
    }

    #endregion
}
