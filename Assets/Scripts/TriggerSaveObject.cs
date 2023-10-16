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

    void Update()
    {
        if (!(videoPlayer.isPlaying))
        {
            rawImageObject.SetActive(false);

            if (IsObjectSaved)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            rawImageObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D()
    {
        IsObjectSaved = true;
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
