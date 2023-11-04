using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip source1;
    [SerializeField]
    private AudioClip source2;
    [SerializeField]
    private AudioClip source3;

    public AudioClip source4;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        MainManager.Instance.PathNumberChanged += HandlePathNumberChanged;
        ToggleMusic(MainManager.Instance.PathNumber);
    }

    private void OnDestroy()
    {
        MainManager.Instance.PathNumberChanged -= HandlePathNumberChanged;
    }

    private void HandlePathNumberChanged(int newPathNumber)
    {
        ToggleMusic(newPathNumber);
    }

    private void ToggleMusic(int number)
    {

        if (number >= 1 && number < 4)
        {
            audioSource.clip = source1;
            audioSource.Play();
        }
        else if (number >= 4 && number < 6)
        {
            audioSource.clip = source2;
            audioSource.Play();
        }
        else if (number >= 6 && number < 8)
        {
            audioSource.clip = source3;
            audioSource.Play();
        }
        else if (number >= 8 && number < 10)
        {
            audioSource.clip = source4;
            audioSource.Play();
        }
    }
}
