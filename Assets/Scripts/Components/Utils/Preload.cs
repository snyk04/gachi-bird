using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using AreYouFruits.Common.ComponentGeneration;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GachiBird.UserInterface.MusicList;
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
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(0.5f);
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoadId);
            asyncOperation.allowSceneActivation = false;
            bool isLogoShown = false;

            while (!asyncOperation.isDone)
            {
                if (!isLogoShown)
                {
                    _audioPlayer.GetHeldItem().Play(_audioClip);
                    yield return StartCoroutine(ShowAndHideLogo(_animationLength));
                    isLogoShown = true;
                }

                if (asyncOperation.progress >= 0.9f)
                {
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        private IEnumerator ShowAndHideLogo(float length)
        {
            Color logoShowColor = Color.white;
            Color logoHideColor = Color.black;

            var changeColorToShowTween = DOTween.To(() => _logo.color, x => _logo.color = x, logoShowColor, length / 2);
            yield return changeColorToShowTween.WaitForCompletion();
            
            var changeColorToHideTween = DOTween.To(() => _logo.color, x => _logo.color = x, logoHideColor, length / 2);
            yield return changeColorToHideTween.WaitForCompletion();
        }
    }
}