using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrigger : MonoBehaviour
{

    public GameObject ObjectVideo;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ObjectVideo.SetActive(true);
            
    }

}
