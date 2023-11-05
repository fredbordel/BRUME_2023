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
    [SerializeField]
    private Animator videoDialogueAnimator;
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
            videoDialogueAnimator.SetTrigger("isOpen");
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
        videoPlayer.targetTexture.Release();
        MainManager.Instance.is3DVideoFinished = false;
        IsObjectSaved = true;
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    void HideFireWhenVideoEnds(VideoPlayer vp)
    {
        videoPlayer.targetTexture.Release();
        MainManager.Instance.is3DVideoFinished = true;

        if (MainManager.Instance.is3DVideoDialogueFinished)
        {
            videoPlayer.clip = null;
            videoDialogueAnimator.SetTrigger("isClose");
            MainManager.Instance.IsDialogueOpened = false;
        }

        if (IsObjectSaved)
        {
            gameObject.SetActive(false);
        }
    }
}
