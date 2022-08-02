using System;
using System.Collections.Generic;
using System.Linq;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Customization;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.Utils
{
    public class SaveGenerator : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private List<PlayerSkinSettings> _allSkins;
        [SerializeField] private List<BoosterSettings> _allMusic;
        
        [Header("Settings")]
        [SerializeField] private string _fileName;

        [Header("Save data")] 
        [SerializeField] private int _bestScore;
        [SerializeField] private int _currentSkinId;
        [SerializeField] private int _amountOfMoney;
        [SerializeField] private List<PlayerSkinSettings> _unlockedSkins;
        [SerializeField] private List<BoosterSettings> _unlockedMusic;
        
        private void Awake()
        {
            GenerateSaveData();
        }

        private void GenerateSaveData()
        {
            IDataSaver dataSaver = DataSaverFactory.Get(_fileName);
            var saveData = new SaveData()
            {
                BestScore = _bestScore,
                CurrentSkinId = _currentSkinId,
                AmountOfMoney = _amountOfMoney,
                StatusOfSkins = GetStatusOfSkins(),
                StatusOfMusic = GetStatusOfMusic()
            };
            dataSaver.Save(saveData);
        }
        private Dictionary<int, bool> GetStatusOfSkins()
        {
            List<int> unlockedSkinsIds = _unlockedSkins.Select(skinSettings => skinSettings.PlayerSkinInfo.Id).ToList();
            var statusOfSkins = new Dictionary<int, bool>();
            foreach (PlayerSkinInfo playerSkinInfo in _allSkins.Select(settings => settings.PlayerSkinInfo))
            {
                bool statusOfSkin = unlockedSkinsIds.Contains(playerSkinInfo.Id);
                statusOfSkins.Add(playerSkinInfo.Id, statusOfSkin);
            }

            return statusOfSkins;
        }
        private Dictionary<int, bool> GetStatusOfMusic()
        {
            List<int> unlockedMusicIds = _unlockedMusic.Select(boosterSettings => boosterSettings.BoosterInfo.Id).ToList();
            var statusOfMusic = new Dictionary<int, bool>();
            foreach (BoosterInfo boosterInfo in _allMusic.Select(settings => settings.BoosterInfo))
            {
                bool statusOfTrack = unlockedMusicIds.Contains(boosterInfo.Id);
                statusOfMusic.Add(boosterInfo.Id, statusOfTrack);
            }

            return statusOfMusic;
        }
    }
}