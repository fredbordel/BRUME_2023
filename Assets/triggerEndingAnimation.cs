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

    void Start()
    {
        if (videoClipEN && videoClipFR && rawImageObject && videoPlayer)
        {
            videoPlayer.loopPointReached += QuitGame;
        }
    }

    void OnTriggerEnter2D()
    {
        audioSource.Stop();
        if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            videoPlayer.clip = videoClipEN;
        }
        else
        {
            videoPlayer.clip = videoClipFR;
        }

        rawImageObject.SetActive(true);
        videoPlayer.Play();
    }

    private void QuitGame(VideoPlayer vp)
    {
        MainManager.DestroyInstance();
        SceneManager.LoadScene("MENU");
        // UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}
