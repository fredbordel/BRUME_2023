using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class triggerEndingAnimation : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private VideoClip videoClipEN;

    [SerializeField]
    private VideoClip videoClipFR;

    [SerializeField]
    private GameObject rawImageObject;

    [SerializeField]
    private AudioSource audioSource;
    private FadeInOut fade;

    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();

        if (videoClipEN && videoClipFR && rawImageObject && videoPlayer)
        {
            videoPlayer.loopPointReached += QuitGame;
        }
    }

    void OnTriggerEnter2D()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("feu");
        videoPlayer.targetTexture.Release();

        if (objs.Length == 0)
        {
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                videoPlayer.clip = videoClipEN;
            }
            else
            {
                videoPlayer.clip = videoClipFR;
            }

            StartCoroutine(_StartEndingVideo());
        }
    }

    public IEnumerator _StartEndingVideo()
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }

        fade.FadeIn();
        yield return new WaitForSeconds(1);
        rawImageObject.SetActive(true);
        videoPlayer.Play();
    }

    private void QuitGame(VideoPlayer vp)
    {
        MainManager.DestroyInstance();
        SceneManager.LoadScene("MENU");
    }
}
