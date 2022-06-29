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
            LoadScene();
        }

        private async void LoadScene()
        {
            await Task.Delay(250);
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

            Vector3 showScale = logoTransform.localScale + 0.1f * Vector3.one;
            Vector3 hideScale = showScale + 0.1f * Vector3.one;

            Color logoShowColor = Color.white;
            Color logoHideColor = Color.black;

            Sequence sequence = DOTween.Sequence()
                .Append(DOTween.To(() => _logo.color, x => _logo.color = x, logoShowColor, length / 2))
                .Append(DOTween.To(() => _logo.color, x => _logo.color = x, logoHideColor, length / 2))
                .Insert(0, logoTransform.DOScale(showScale, length / 2))
                .Insert(length / 2, logoTransform.DOScale(hideScale, length / 2));
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