using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private SerializationManager serializationManager;

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

    private void Awake()
    {
        IsGameStarted = false;
        IsGameStopped = false;
        IsGameInFlexMode = false;
        IsGameInFirstStartMode = false;
        Score = 0;
    }

    private void Start()
    {
        serializationManager = SerializationManager.Instance;

        StatusOfSkinsDict = serializationManager.LoadStatusOfSkins();
        StatusOfMusicDict = serializationManager.LoadStatusOfMusic();
        AmountOfMoney = serializationManager.LoadAmountOfMoney();
        SkinID = serializationManager.LoadSkinID();
    }
}
