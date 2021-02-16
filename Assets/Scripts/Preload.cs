using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class Preload : MonoBehaviour
{
    public Image logo;
    public Transform logoTransform;
    public AudioSource audioPlayer;

    void Start()
    {
        StartCoroutine(ShowAndCloseLogo());
    }

    public IEnumerator ShowAndCloseLogo()
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainScene");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone) 
        {
            float i = 0f;
            while (i <= 1) 
            {
                if ((i > 0.49f) && (i < 0.5f)) audioPlayer.Play();
                logo.color = new Color(i, i, i);
                i += 0.01f;
                logoTransform.localScale = new Vector2(logoTransform.localScale.x + 0.0005f, logoTransform.localScale.y + 0.0005f);
                yield return new WaitForSeconds(0.00125f);
            }
            while (i >= 0) 
            {
                logo.color = new Color(i, i, i);
                i -= 0.01f;
                logoTransform.localScale = new Vector2(logoTransform.localScale.x + 0.0005f, logoTransform.localScale.y + 0.0005f);
                yield return new WaitForSeconds(0.00125f);
            }
            if (asyncOperation.progress >= 0.9f) 
            {
                yield return new WaitForSeconds(0.25f);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
