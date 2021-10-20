using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    #region Properties

    private UIManager uI;
    private ComponentsManager components;
    private SpawningObjectsManager spawningObjects;
    private GameStateManager gameState;
    private SpritesManager sprites;
    private PrefabsManager prefabs;
    private SerializationManager serializationManager;
    private FlexModeManager flexMode;
    private DrawNumberManager drawNumber;
    private GamePreferencesManager gamePreferences;
    private AudioPlayerManager audioPlayer;
    private ScoreManager scoreManager;
    private SkinsManager skins;
    private MusicListManager musicList;

    private float cameraShift;

    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        components = GetComponent<ComponentsManager>();
        uI = GetComponent<UIManager>();
        spawningObjects = GetComponent<SpawningObjectsManager>();
        gameState = GetComponent<GameStateManager>();
        sprites = GetComponent<SpritesManager>();
        prefabs = GetComponent<PrefabsManager>();
        flexMode = GetComponent<FlexModeManager>();
        drawNumber = GetComponent<DrawNumberManager>();
        gamePreferences = GetComponent<GamePreferencesManager>();
        audioPlayer = FindObjectOfType<AudioPlayerManager>();
        scoreManager = GetComponent<ScoreManager>();
        skins = GetComponent<SkinsManager>();
        musicList = GetComponent<MusicListManager>();

        cameraShift = 0.12f;
    }
    private void Start()
    {
        serializationManager = SerializationManager.Instance;
        
        if (serializationManager.CheckIfThisIsFirstStart())
        {
            gameState.IsGameInFirstStartMode = true;
            uI.firstStartInterface.SetActive(true);
        }
        else
        {
            uI.prestartInterface.SetActive(true);
        }
        components.audioPlayer.PlaySound(
            components.audioPlayer.backgroundMusic,
            components.audioPlayer.backgroundSoundAudioSource,
            0.025f,
            true
            );

        components.playerScript.GetComponent<SpriteRenderer>().sprite = sprites.FacesArray[gameState.SkinID];
        components.playerRigidbody.AddForce(transform.right * gamePreferences.gameSpeed, ForceMode2D.Force);

        spawningObjects.DrawBackgroundPart(2);
        spawningObjects.DrawGroundPart(2);
        spawningObjects.BackgroundSpawningCoroutine = StartCoroutine(spawningObjects.DrawBackground(gamePreferences.backgroundSpawningDelay));
        spawningObjects.GroundSpawningCoroutine = StartCoroutine(spawningObjects.DrawGround(gamePreferences.groundSpawningDelay));
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (!gameState.IsGameStopped) && (!gameState.IsGameInFirstStartMode))
        {
            if (!gameState.IsGameStarted) StartGame();
            components.playerRigidbody.velocity = new Vector2(components.playerRigidbody.velocity.x, gamePreferences.impulseScale);
            if (!gameState.IsGameInFlexMode)
            {
                audioPlayer.PlaySound(
                audioPlayer.spankSound,
                audioPlayer.flyingSoundAudioSource,
                1f,
                false
                );
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ScreenCapture.CaptureScreenshot("Screenshot_4.png");
        }
    }
    private void FixedUpdate()
    {
        var position = components.cameraTransform.position;
        position = new Vector3(
            components.playerTransform.position.x + cameraShift,
            position.y,
            position.z
            );
        components.cameraTransform.position = position;
    }

    #endregion

    #region Methods

    private void StartGame()
    {
        cameraShift += gamePreferences.cameraShift;
        gameState.IsGameStarted = true;

        scoreManager.RefreshScoreCounter();
        uI.scoreMenu.SetActive(true);
        uI.prestartInterface.SetActive(false);

        components.playerRigidbody.gravityScale = gamePreferences.gravityScale;
        spawningObjects.PlayerStartPosition = components.playerTransform.position;

        spawningObjects.ObstacleSpawningCoroutine = StartCoroutine(spawningObjects.DrawObstacles(gamePreferences.obstacleSpawningDelay));
        spawningObjects.BoosterSpawningCoroutine = StartCoroutine(spawningObjects.DrawBoosters(gamePreferences.boosterSpawningDelay));

        spawningObjects.DrawBooster(1);
    }
    public void StopGame()
    {
        gameState.IsGameStopped = true;
        if (gameState.IsGameInFlexMode) flexMode.StopFlexingAfterDeath();

        spawningObjects.StopSpawnCoroutines();

        uI.gameOverInterface.SetActive(true);
        uI.scoreMenu.SetActive(false);

        if (gameState.Score > scoreManager.CurrentBestScoreForNextImage()) uI.gameOverInterface.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);

        drawNumber.DrawScore(gameState.Score, uI.gameOverScoreMenu, sprites.smallDigitsDict, sprites.DefaultSpritesArray);
        drawNumber.DrawScore(scoreManager.CurrentBestScoreForDrawing(), uI.gameOverBestScoreMenu, sprites.smallDigitsDict, sprites.DefaultSpritesArray);

        serializationManager.SaveAmountOfMoney(gameState.AmountOfMoney);

        components.audioPlayer.PlaySound(
            components.audioPlayer.deathSoundArray[gameState.SkinID],
            components.audioPlayer.inGameSoundAudioSource,
            1,
            false
            );
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OpenShop()
    {
        components.audioPlayer.StopSound(components.audioPlayer.inGameSoundAudioSource);
        uI.gameOverInterface.SetActive(false);
        uI.shopInterface.SetActive(true);
        OpenShopPage(0);
    }
    public void CloseShop()
    {
        components.audioPlayer.StopSound(components.audioPlayer.inGameSoundAudioSource);
        uI.shopInterface.SetActive(false);
        uI.gameOverInterface.SetActive(true);
    }
    public void OpenShopPage(int pageID)
    {
        if (uI.shopInterface.transform.GetChild(4) != null)
        {
            Destroy(uI.shopInterface.transform.GetChild(4).gameObject);
        }
        Instantiate(prefabs.shopPagesArray[pageID],
            new Vector2(Screen.width / 2, Screen.height / 2),
            Quaternion.identity,
            uI.shopInterface.transform
            );
        gameState.CurrentShopPageID = pageID;
        drawNumber.DrawMoney(gameState.AmountOfMoney, uI.shopMoneyCounterMenu, sprites.smallDigitsDict, sprites.DefaultSpritesArray);
    }
    public void OpenInfoInterface()
    {
        gameState.IsGameInFirstStartMode = true;
        uI.gameOverInterface.SetActive(false);
        uI.infoInterface.SetActive(true);
    }
    public void CloseInfoInterface()
    {
        gameState.IsGameInFirstStartMode = false;
        uI.infoInterface.SetActive(false);
        uI.gameOverInterface.SetActive(true);
    }
    public void CloseFirstStartInterface()
    {
        gameState.IsGameInFirstStartMode = false;
        uI.firstStartInterface.SetActive(false);
        uI.prestartInterface.SetActive(true);
    }
    public void OpenMusicList()
    {
        musicList.ConfigureSpritesAndButtons();
        uI.gameOverInterface.SetActive(false);
        uI.musicListInterface.SetActive(true);
    }
    public void CloseMusicList()
    {
        audioPlayer.StopSound(audioPlayer.flexModeSoundAudioSource);
        audioPlayer.ResumeSound(audioPlayer.backgroundSoundAudioSource);
        uI.musicListInterface.SetActive(false);
        uI.gameOverInterface.SetActive(true);
    }

    #endregion
}
