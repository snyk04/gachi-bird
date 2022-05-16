using System.Collections.Generic;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Environment;
using GachiBird.Environment.Objects;
using GachiBird.Flex;
using GachiBird.Serialization;
using UnityEngine;

namespace GachiBird.UserInterface.MusicList
{
    public class MusicListCreator : MonoBehaviour
    {
#nullable disable
        [Header("References")]
        [SerializeField] private SerializedInterface<IComponent<IBoosterSpawner>> _boosterSpawner;
        [SerializeField] private SerializedInterface<IComponent<IGameSaver>> _gameSaver;
        [SerializeField] private SerializedInterface<IComponent<IFlexModeHandler>> _flexModeHandler;
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _audioPlayer;

        [Header("Objects")]
        [SerializeField] private RectTransform _musicListElementsParentObject;
        [SerializeField] private GameObject _musicListElementPrefab;
#nullable enable

        private readonly List<IMusicListElement> _musicListElements = new List<IMusicListElement>();

        private void Start()
        {
            _flexModeHandler.GetHeldItem().OnFlexModeStart += HandleFlexModeStart;

            CreateMusicList();
        }

        private void CreateMusicList()
        {
            Dictionary<int, bool> statusOfMusic = _gameSaver.GetHeldItem().LoadStatusOfMusic();
            foreach (BoosterInfo boosterInfo in _boosterSpawner.GetHeldItem().BoosterInfos)
            {
                CreateMusicListElement(boosterInfo, statusOfMusic);
            }
        }
        private void CreateMusicListElement(BoosterInfo boosterInfo, IReadOnlyDictionary<int, bool> statusOfMusic)
        {
            GameObject? musicListElementObject = Instantiate(_musicListElementPrefab, _musicListElementsParentObject);
            IMusicListElement musicListElement = musicListElementObject.GetComponent<MusicListElementComponent>().HeldItem;
            _musicListElements.Add(musicListElement);
            
            musicListElement.Setup(boosterInfo, _audioPlayer.GetHeldItem());
            if (statusOfMusic.ContainsKey(boosterInfo.Id) && statusOfMusic[boosterInfo.Id])
            {
                musicListElement.Activate();
            }
        }

        private void HandleFlexModeStart(BoosterInfo boosterInfo)
        {
            _musicListElements[boosterInfo.Id].Activate();
        }
    }
}