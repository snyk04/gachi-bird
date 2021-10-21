using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class SerializationManager : MonoBehaviour
    {
        [Serializable]
        private class SaveData
        {
            private bool _isFirstStart;
            private int _bestScore;
            private int _currentSkinId;
            private int _amountOfMoney;
            private Dictionary<int, bool> _statusOfSkins;
            private Dictionary<int, bool> _statusOfMusic;
            
            public bool IsFirstStart => _isFirstStart;
            public int BestScore => _bestScore;
            public int CurrentSkinId => _currentSkinId;
            public int AmountOfMoney => _amountOfMoney;
            public Dictionary<int, bool> StatusOfSkins => _statusOfSkins;
            public Dictionary<int, bool> StatusOfMusic => _statusOfMusic;

            public SaveData()
            {
                _isFirstStart = true;
                _bestScore = 0;
                _currentSkinId = 0;
                _amountOfMoney = 0;
                _statusOfSkins = new Dictionary<int, bool>();
                _statusOfMusic = new Dictionary<int, bool>();
            }

            public void SetIsFirstStart(bool isFirstStart)
            {
                _isFirstStart = isFirstStart;
            }
            public void SetBestScore(int bestScore)
            {
                _bestScore = bestScore;
            }
            public void SetCurrentSkinId(int currentSkinId)
            {
                _currentSkinId = currentSkinId;
            }
            public void SetAmountOfMoney(int amountOfMoney)
            {
                _amountOfMoney = amountOfMoney;
            }
            public void SetStatusOfSkins(Dictionary<int, bool> statusOfSkins)
            {
                _statusOfSkins = statusOfSkins;
            }
            public void SetStatusOfMusic(Dictionary<int, bool> statusOfMusic)
            {
                _statusOfMusic = statusOfMusic;
            }
        }
        
        private SaveData _saveData;
        
        private void Awake()
        {
            TryToLoadSaveData();
        }
        
        private void TryToLoadSaveData()
        {
            var bf = new BinaryFormatter();

            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                var file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
                _saveData = (SaveData) bf.Deserialize(file);
                file.Close();
            }
            else
            {
                var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
                _saveData = new SaveData();
                bf.Serialize(file, _saveData);
                file.Close();
            }
        }
        
        public bool CheckIfThisIsFirstStart()
        {
            if (!_saveData.IsFirstStart)
            {
                return false;
            }
            
            _saveData.SetIsFirstStart(false);
            return true;
        }

        public void SaveBestScore(int score)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            _saveData.SetBestScore(score);
            bf.Serialize(file, _saveData);
            file.Close();
        }
        public void SaveCurrentSkinId(int skinID)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            _saveData.SetCurrentSkinId(skinID);
            bf.Serialize(file, _saveData);
            file.Close();
        }
        public void SaveAmountOfMoney(int amountOfMoney)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            _saveData.SetAmountOfMoney(amountOfMoney);
            bf.Serialize(file, _saveData);
            file.Close();
        }
        public void SaveStatusOfSkins(Dictionary<int, bool> statusOfSkins)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            _saveData.SetStatusOfSkins(statusOfSkins);
            bf.Serialize(file, _saveData);
            file.Close();
        }
        public void SaveStatusOfMusic(Dictionary<int, bool> statusOfMusic)
        {
            var bf = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            _saveData.SetStatusOfMusic(statusOfMusic);
            bf.Serialize(file, _saveData);
            file.Close();
        }
        
        public int LoadBestScore()
        {
            return _saveData.BestScore;
        }
        public int LoadCurrentSkinId()
        {
            return _saveData.CurrentSkinId;
        }
        public int LoadAmountOfMoney()
        {
            return _saveData.AmountOfMoney;
        }
        public Dictionary<int, bool> LoadStatusOfSkins()
        {
            return _saveData.StatusOfSkins;
        }
        public Dictionary<int, bool> LoadStatusOfMusic()
        {
            return _saveData.StatusOfMusic;

        }
    }
}
