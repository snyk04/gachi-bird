using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common.ComponentGeneration;
using DG.Tweening;
using GachiBird.UserInterface.MusicList;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GachiBird.Utils
{
    public class Preload : MonoBehaviour
    {
#nullable disable
        [Header("References")] [SerializeField]
        private SerializedInterface<IComponent<IAudioPlayer>> _audioPlayer;

        [Header("Objects")] [SerializeField] private Image _logo;

        [Header("Settings")] [SerializeField] private int _sceneToLoadId;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _animationLength;
#nullable enable

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void Start()
        {
            LoadScene();
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }

        private async void LoadScene()
        {
            await Task.Delay(500, _cancellationTokenSource.Token);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoadId);
            asyncOperation.allowSceneActivation = false;
            bool isLogoShown = false;

            while (!asyncOperation.isDone)
            {
                if (!isLogoShown)
                {
                    _audioPlayer.GetHeldItem().Play(_audioClip);
                    await ShowAndHideLogo(_animationLength);
                    isLogoShown = true;
                }

                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                await Task.Yield();
            }
        }

        private async Task ShowAndHideLogo(float length)
        {
            Transform logoTransform = _logo.transform;

            Vector3 startScale = logoTransform.localScale;
            Vector3 logoShowScale = startScale + 0.05f * Vector3.one;
            Vector3 logoHideScale = logoShowScale + 0.05f * Vector3.one;

            Color logoShowColor = Color.white;
            Color logoHideColor = Color.black;

            logoTransform.DOScale(logoShowScale, length / 2);
            DOTween.To(() => _logo.color, x => _logo.color = x, logoShowColor, length / 2);
            await Task.Delay((int) (length / 2 * 1000), _cancellationTokenSource.Token);

            logoTransform.DOScale(logoHideScale, length / 2);
            DOTween.To(() => _logo.color, x => _logo.color = x, logoHideColor, length / 2);
            await Task.Delay((int) (length / 2 * 1000), _cancellationTokenSource.Token);
        }
    }
}