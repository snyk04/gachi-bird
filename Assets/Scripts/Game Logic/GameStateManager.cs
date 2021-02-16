using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private SerializationManager serialization;

    public Dictionary<int, bool> StatusOfSkinsDict { get; set; }
    public Dictionary<int, bool> StatusOfMusicDict { get; set; }
    public int CurrentShopPageID { get; set; }
    public bool IsGameStarted { get; set; }
    public bool IsGameStopped { get; set; }
    public bool IsGameInFlexMode { get; set; }
    public bool IsGameInFirstStartMode { get; set; }
    public int AmountOfMoney { get; set; }
    public int SkinID { get; set; }
    public int Score { get; set; }

    void Awake()
    {
        serialization = GetComponent<SerializationManager>();

        StatusOfSkinsDict = serialization.LoadStatusOfSkins();
        StatusOfMusicDict = serialization.LoadStatusOfMusic();
        IsGameStarted = false;
        IsGameStopped = false;
        IsGameInFlexMode = false;
        IsGameInFirstStartMode = false;
        AmountOfMoney = serialization.LoadAmountOfMoney();
        SkinID = serialization.LoadSkinID();
        Score = 0;
    }
}
