using System.Collections;
using UnityEngine;


public class AudioPlayerManager : MonoBehaviour
{
    public AudioSource backgroundSoundAudioSource;
    public AudioSource flyingSoundAudioSource;
    public AudioSource inGameSoundAudioSource;
    public AudioSource flexModeSoundAudioSource;
    [Space]
    public AudioClip backgroundMusic;
    public AudioClip doYouLikeWhatYouSeeSound;
    public AudioClip yeeaahSound;
    public AudioClip spankSound;
    public AudioClip wooSound;
    public AudioClip[] plusOnePointSoundArray;
    public AudioClip[] deathSoundArray;
    public AudioClip[] flexModeMusicArray;

    private Coroutine stopBackgroundMusicCoroutine;

    public void PlaySound(AudioClip clip, AudioSource audioSource, float volume, bool isLooped)
    {
        audioSource.loop = isLooped;
        audioSource.volume = volume;
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlaySoundFromArray(AudioClip[] clipArray, AudioSource audioSource)
    {
        System.Random rnd = new System.Random();
        audioSource.clip = clipArray[rnd.Next(0, clipArray.Length)];
        audioSource.Play();
    }

    public void PauseSound(AudioSource audioSource)
    {
        audioSource.Pause();
    }
    public void ResumeSound(AudioSource audioSource)
    {
        audioSource.UnPause();
    }
    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void PlayFlexModeMusic(int musicID)
    {
        if(stopBackgroundMusicCoroutine != null) 
        { 
            StopCoroutine(stopBackgroundMusicCoroutine); 
        }
        stopBackgroundMusicCoroutine = StartCoroutine(PauseBackgroundMusicForFixedTime(flexModeMusicArray[musicID].length));
        StopSound(flexModeSoundAudioSource);
        PlaySound(
            flexModeMusicArray[musicID],
            flexModeSoundAudioSource,
            1f,
            false
            );
    }
    public IEnumerator PauseBackgroundMusicForFixedTime(float time)
    {
        PauseSound(backgroundSoundAudioSource);
        yield return new WaitForSeconds(time + 0.5f);
        ResumeSound(backgroundSoundAudioSource);
    }
}
