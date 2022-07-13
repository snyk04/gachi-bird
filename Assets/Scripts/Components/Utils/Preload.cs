using System;
using AreYouFruits.Common.ComponentGeneration;
using DG.Tweening;
using GachiBird.UserInterface.MusicList;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GachiBird.Utils
{
    public class Preload : MonoBehaviour
    {
#nullable disable
        [Header("References")] 
        [SerializeField] private SerializedInterface<IComponent<IAudioPlayer>> _audioPlayer;

        [Header("Objects")] 
        [SerializeField] private Image _logo;

        [Header("Settings")] 
        [SerializeField] private int _sceneToLoadId;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _animationLength;
#nullable enable

        private void Start()
        {
            _ = LoadScene();
        }

        private async Task LoadScene()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(250));
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(_sceneToLoadId);
            sceneLoading.allowSceneActivation = false;
            bool isLogoShown = false;

            while (!sceneLoading.isDone)
            {
                if (!isLogoShown)
                {
                    _audioPlayer.GetHeldItem().Play(_audioClip);
                    await ShowAndHideLogo(_animationLength);
                    isLogoShown = true;
                }

                const float loadedSceneProgress = 0.9f;

                if (sceneLoading.progress >= loadedSceneProgress)
                {
                    sceneLoading.allowSceneActivation = true;
                }

                await Task.Yield();
            }
        }

        private async Task ShowAndHideLogo(float length)
        {
            float halfLength = length / 2;
            Transform logoTransform = _logo.transform;

            // todo: 0.1f - wtf?
            Vector3 showScale = logoTransform.localScale + 0.1f * Vector3.one;
            Vector3 hideScale = showScale + 0.1f * Vector3.one;

            Color logoShowColor = Color.white;
            Color logoHideColor = Color.black;

            // todo: atPosition: 0 - describe constant
            Sequence sequence = DOTween.Sequence()
                .Append(DOTween.To(() => _logo.color, x => _logo.color = x, logoShowColor, length / 2))
                .Append(DOTween.To(() => _logo.color, x => _logo.color = x, logoHideColor, length / 2))
                .Insert(0, logoTransform.DOScale(showScale, halfLength))
                .Insert(halfLength, logoTransform.DOScale(hideScale, halfLength));
            
            bool isAnimationDone = false;
            sequence.onComplete += () => { isAnimationDone = true; };
            sequence.Play();

            while (!isAnimationDone)
            {
                await Task.Yield();
            }
        }
    }
}