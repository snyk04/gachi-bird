using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    [Serializable]
    private class SaveData
    {
        public int bestScore;
        public int skinID;
        public int amountOfMoney;
        public Dictionary<int, bool> statusOfSkins;
        public Dictionary<int, bool> statusOfMusic;
        public bool isFirstStart;

        public SaveData()
        {
            bestScore = 0;
            skinID = 0;
            amountOfMoney = 0;
            statusOfSkins = new Dictionary<int, bool>
            {
                {0, true},
                {1, false},
                {2, false},
                {3, false},
                {4, false},
                {5, false}
            };
            statusOfMusic = new Dictionary<int, bool>
            {
                {0, false},
                {1, false},
                {2, false},
                {3, false},
                {4, false},
                {5, false},
                {6, false},
                {7, false},
                {8, false},
                {9, false},
                {10, false},
                {11, false},
                {12, false},
                {13, false}
            };
            isFirstStart = true;
        }
    }

    #region Properties
    
    public static SerializationManager Instance { get; set; }

    private SaveData saveData;
    
    #endregion

    #region MonoBehaviour methods

    private void Awake()
    {
        Instance = this;

        var bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            var file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            saveData = (SaveData) bf.Deserialize(file);
            file.Close();
        }
        else
        {
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            saveData = new SaveData();
            bf.Serialize(file, saveData);
            file.Close();
        }
    }

    #endregion

    #region Methods

    public void SaveBestScore(int score)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        saveData.bestScore = score;
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void SaveSkinID(int skinID)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        saveData.skinID = skinID;
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void SaveAmountOfMoney(int amountOfMoney)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        saveData.amountOfMoney = amountOfMoney;
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void SaveStatusOfSkins(Dictionary<int, bool> statusOfSkins)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        saveData.statusOfSkins = statusOfSkins;
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void SaveStatusOfMusic(Dictionary<int, bool> statusOfMusic)
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        saveData.statusOfMusic = statusOfMusic;
        bf.Serialize(file, saveData);
        file.Close();
    }

    public int LoadBestScore()
    {
        return saveData.bestScore;
    }
    public int LoadSkinID()
    {
        return saveData.skinID;
    }
    public int LoadAmountOfMoney()
    {
        return saveData.amountOfMoney;
    }
    public Dictionary<int, bool> LoadStatusOfSkins()
    {
        return saveData.statusOfSkins;
    }
    public Dictionary<int, bool> LoadStatusOfMusic()
    {
        return saveData.statusOfMusic;

    }
    public bool CheckIfThisIsFirstStart()
    {
        if (!saveData.isFirstStart)
        {
            return false;
        }
        
        saveData.isFirstStart = false;
        return true;
    }

    #endregion
}
