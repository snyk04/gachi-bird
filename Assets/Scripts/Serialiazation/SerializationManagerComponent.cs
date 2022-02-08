#nullable enable

using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using UnityEngine;

namespace GachiBird.Serialization
{
    public sealed class SerializationManagerComponent : AbstractComponent<ISerializationManager>
    {
#nullable disable
        [SerializeField] private string _fileName = "SaveData.dat";
#nullable enable

        protected override ISerializationManager Create()
        {
            return new SerializationManager(DataSaverFactory.Get<SaveData>(_fileName));
        }
    }

    public interface ISerializationManager
    {
        int LoadBestScore();
    }

    public sealed class SerializationManager : ISerializationManager
    {
        private readonly IDataSaver<SaveData> _saver;

        private readonly SaveData _saveData;

        public SerializationManager(IDataSaver<SaveData> dataSaver)
        {
            _saver = dataSaver;

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

        public void SaveStatusOfSkins(bool[] statusOfSkins)
        {
            _saveData.StatusOfSkins = statusOfSkins;
            _saver.Save(_saveData);
        }

        public void SaveStatusOfMusic(bool[] statusOfMusic)
        {
            _saveData.StatusOfMusic = statusOfMusic;
            _saver.Save(_saveData);
        }

        public int LoadBestScore() => _saveData.BestScore;
        public int LoadCurrentSkinId() => _saveData.CurrentSkinId;
        public int LoadAmountOfMoney() => _saveData.AmountOfMoney;
        public bool[] LoadStatusOfSkins() => _saveData.StatusOfSkins;
        public bool[] LoadStatusOfMusic() => _saveData.StatusOfMusic;
    }
}
