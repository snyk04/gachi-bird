using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class SerializationManager : MonoBehaviour
{
    [Serializable] private class SaveData
    {
        public int savedBestScore;
        public int savedSkinID;
        public int savedAmountOfMoney;
        public Dictionary<int, bool> savedStatusOfSkins;
        public bool firstStart;
        public Dictionary<int, bool> savedStatusOfMusic;
    }

    public void SaveBestScore(int score)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/BestScore.dat");
        SaveData data = new SaveData();
        data.savedBestScore = score;
        bf.Serialize(file, data);
        file.Close();
    }
    public void SaveSkinID(int skinID)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SkinID.dat");
        SaveData data = new SaveData();
        data.savedSkinID = skinID;
        bf.Serialize(file, data);
        file.Close();
    }
    public void SaveAmountOfMoney(int amountOfMoney)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/AmountOfMoney.dat");
        SaveData data = new SaveData();
        data.savedAmountOfMoney = amountOfMoney;
        bf.Serialize(file, data);
        file.Close();
    }
    public void SaveStatusOfSkins(Dictionary<int, bool> statusOfSkins)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/StatusOfSkins.dat");
        SaveData data = new SaveData();
        data.savedStatusOfSkins = statusOfSkins;
        bf.Serialize(file, data);
        file.Close();
    }
    public void SaveStatusOfMusic(Dictionary<int, bool> statusOfMusic)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/StatusOfMusic.dat");
        SaveData data = new SaveData();
        data.savedStatusOfMusic = statusOfMusic;
        bf.Serialize(file, data);
        file.Close();
    }

    public int LoadBestScore()
    {
        if (File.Exists(Application.persistentDataPath + "/BestScore.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/BestScore.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.savedBestScore;
        } else return -1;
    }
    public int LoadSkinID()
    {
        if (File.Exists(Application.persistentDataPath + "/SkinID.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SkinID.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.savedSkinID;
        } else {
            SaveSkinID(0);
            return 0;
        }

    }
    public int LoadAmountOfMoney()
    {
        if (File.Exists(Application.persistentDataPath + "/AmountOfMoney.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/AmountOfMoney.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.savedAmountOfMoney;
        } else {
            SaveAmountOfMoney(0);
            return 0;
        }
    }
    public Dictionary<int, bool> LoadStatusOfSkins()
    {
        if (File.Exists(Application.persistentDataPath + "/StatusOfSkins.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/StatusOfSkins.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.savedStatusOfSkins;
        } else {
            var statusOfSkins = new Dictionary<int, bool>
            {
                {0, true},
                {1, false },
                {2, false },
                {3, false },
                {4, false },
                {5, false }
            };
            SaveStatusOfSkins(statusOfSkins);
            return statusOfSkins;
        }
    }
    public Dictionary<int, bool> LoadStatusOfMusic()
    {
        if(File.Exists(Application.persistentDataPath + "/StatusOfMusic.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/StatusOfMusic.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            return data.savedStatusOfMusic;
        }
        else
        {
            var statusOfMusic = new Dictionary<int, bool>
            {
                {0, false},
                {1, false },
                {2, false },
                {3, false },
                {4, false },
                {5, false },
                {6, false },
                {7, false },
                {8, false },
                {9, false },
                {10, false },
                {11, false },
                {12, false },
                {13, false }
            };
            SaveStatusOfMusic(statusOfMusic);
            return statusOfMusic;
        }
    }
    public bool CheckIfThisIsFirstStart()
    {
        if (File.Exists(Application.persistentDataPath + "/FirstStart.dat")) {
            return false;
        } else {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/FirstStart.dat");
            SaveData data = new SaveData();
            data.firstStart = false;
            bf.Serialize(file, data);
            file.Close();
            return true; 
        }
    }
}
