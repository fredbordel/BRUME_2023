using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class TriggerSaveObject : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject rawImageObject;
    [SerializeField]
    private VideoClip videoClip;
    [SerializeField]
    private AudioSource saveObjectSound;
    private bool IsObjectSaved = false;
    private bool IsObjectWithVideo = false;

    void Start()
    {
        if (videoClip && rawImageObject && videoPlayer)
        {
            IsObjectWithVideo = true;
        }

        if (IsObjectWithVideo)
        {
            videoPlayer.loopPointReached += HideFireWhenVideoEnds;
        }
    }

    void OnTriggerEnter2D()
    {
        if (IsObjectWithVideo)
        {
            saveObjectSound.Play();
            PlayVideo();
        }
        else
        {
            IsObjectSaved = true;
            gameObject.SetActive(false);
        }
    }

    void PlayVideo()
    {
        IsObjectSaved = true;
        rawImageObject.SetActive(true);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    void HideFireWhenVideoEnds(VideoPlayer vp)
    {
        rawImageObject.SetActive(false);

        if (IsObjectSaved)
        {
            gameObject.SetActive(false);
        }
    }
}
