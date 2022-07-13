
using System.Collections.Generic;

namespace GachiBird.Serialization
{
    public sealed class GameSaverLoader : IGameSaverLoader
    {
        private readonly IDataSaver _saver;
        private SaveData _saveData;

        public int BestScore
        {
            get => _saveData.BestScore;
            set
            {
                if (value == _saveData.BestScore)
                {
                    return;
                }
                
                _saveData.BestScore = value;
                _saver.Save(_saveData);
            }
        }

        public int SkinId
        {
            get => _saveData.CurrentSkinId;
            set
            {
                if (value == _saveData.CurrentSkinId)
                {
                    return;
                }

                _saveData.CurrentSkinId = value;
                _saver.Save(_saveData);
            }
        }

        public int MoneyAmount
        {
            get => _saveData.AmountOfMoney;
            set
            {
                if (value == _saveData.AmountOfMoney)
                {
                    return;
                }

                _saveData.AmountOfMoney = value;
                _saver.Save(_saveData);
            }
        }

        public IReadOnlyDictionary<int, bool> SkinStatus
        {
            get => _saveData.StatusOfSkins;
            set
            {
                if (value == _saveData.StatusOfSkins)
                {
                    return;
                }
                
                _saveData.StatusOfSkins = value;
                _saver.Save(_saveData);
            }
        }

        public IReadOnlyDictionary<int, bool> MusicStatus
        {
            get => _saveData.StatusOfMusic;
            set
            {
                if (value == _saveData.StatusOfMusic)
                {
                    return;
                }
                
                _saveData.StatusOfMusic = value;
                _saver.Save(_saveData);
            }
        }

        public GameSaverLoader(IDataSaver dataSaver)
        {
            _saver = dataSaver;

            _saveData = _saver.TryLoadSaveData(out SaveData? saveData) ? saveData!.Value : SaveData.GetDefault();
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
    }
}