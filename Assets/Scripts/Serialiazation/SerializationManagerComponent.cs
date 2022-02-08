using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class SerializationManagerComponent : AbstractComponent<SerializationManager>
    {
        [SerializeField] private string _fileName = "SaveData.dat";
        
        protected override SerializationManager Create() => new SerializationManager(_fileName);
    }
    
    public sealed class SerializationManager
    {
        private readonly DataSaver<SaveData> _saver;
        
        private readonly SaveData _saveData;
        
        public SerializationManager(string fileName)
        {
            _saver = new DataSaver<SaveData>(fileName);
            
            if (!_saver.TryLoadSaveData(out _saveData))
            {
                _saveData = new SaveData();
            }
        }
        
        public bool CheckIfThisIsFirstStart()
        {
            if (!_saveData.IsFirstLaunch)
            {
                return false;
            }
            
            _saveData.IsFirstLaunch = false;
            
            return true;
        }

        public void SaveBestScore(int score)
        {
            _saveData.BestScore = score;
            _saver.Save(_saveData);
        }
        
        public void SaveCurrentSkinId(int skinID)
        {
            _saveData.CurrentSkinId = skinID;
            _saver.Save(_saveData);
        }
        public void SaveAmountOfMoney(int amountOfMoney)
        {
            _saveData.AmountOfMoney = amountOfMoney;
            _saver.Save(_saveData);
        }
        public void SaveStatusOfSkins(Dictionary<int, bool> statusOfSkins)
        {
            _saveData.StatusOfSkins = statusOfSkins;
            _saver.Save(_saveData);
        }
        public void SaveStatusOfMusic(Dictionary<int, bool> statusOfMusic)
        {
            _saveData.StatusOfMusic = statusOfMusic;
            _saver.Save(_saveData);
        }
        
        public int LoadBestScore() => _saveData.BestScore;
        public int LoadCurrentSkinId() => _saveData.CurrentSkinId;
        public int LoadAmountOfMoney() => _saveData.AmountOfMoney;
        public Dictionary<int, bool> LoadStatusOfSkins() => _saveData.StatusOfSkins;
        public Dictionary<int, bool> LoadStatusOfMusic() => _saveData.StatusOfMusic;
    }
}
