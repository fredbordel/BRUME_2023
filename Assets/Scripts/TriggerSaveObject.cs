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
    private bool IsObjectSaved = false;

    void Start()
    {
        videoPlayer.loopPointReached += DoSomethingWhenVideoEnds;
    }

    void OnTriggerEnter2D()
    {
        PlayVideo();
    }

    void PlayVideo()
    {
        IsObjectSaved = true;
        rawImageObject.SetActive(true);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    void DoSomethingWhenVideoEnds(VideoPlayer vp)
    {
        rawImageObject.SetActive(false);

        if (IsObjectSaved)
        {
            gameObject.SetActive(false);
        }
    }
}
