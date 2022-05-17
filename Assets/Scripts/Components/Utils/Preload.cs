using System.Collections;
using AreYouFruits.Common.ComponentGeneration;
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
                    yield return ShowAndHideLogo(_animationLength);
                    isLogoShown = true;
                }
                if (asyncOperation.progress >= 0.9f) 
                {
                    // yield return new WaitForSeconds(0.25f);
                    asyncOperation.allowSceneActivation = true;
                }
                yield return null;
            }
        }

        private IEnumerator ShowAndHideLogo(float length)
        {
            Transform logoTransform = _logo.transform;
            
            Vector3 startScale = logoTransform.localScale;
            Vector3 logoShowScale = startScale + 0.05f * Vector3.one;
            Vector3 logoHideScale = logoShowScale + 0.05f * Vector3.one;
            
            Color startColor = Color.black;
            Color logoShowColor = Color.white;
            
            for (int i = 1; i < 101; i++)
            {
                _logo.color = Color.Lerp(startColor, logoShowColor, i / 100f);
                logoTransform.localScale = Vector3.Lerp(startScale, logoShowScale, i/ 100f);
                yield return new WaitForSeconds(length / 2 / 100);
            }
            
            for (int i = 1; i < 101; i++)
            {
                _logo.color = Color.Lerp(logoShowColor, startColor, i / 100f);
                logoTransform.localScale = Vector3.Lerp(logoShowScale, logoHideScale, i / 100f);
                yield return new WaitForSeconds(length / 2 / 100);
            }
        }
    }
}