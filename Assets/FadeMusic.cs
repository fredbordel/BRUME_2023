using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{

    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(_FadeMusic());
    }

    public IEnumerator _FadeMusic()
    {
        float startVolume = 1;
        while (audioSource.volume <= 0.5)
        {
            audioSource.volume += startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }
    }
}
