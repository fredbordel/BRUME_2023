using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip source1;
    public AudioClip source2;
    public AudioClip source3;

    private void OnEnable()
    {
        MainManager.Instance.PathNumberChanged += HandlePathNumberChanged;
    }

    private void OnDisable()
    {
        MainManager.Instance.PathNumberChanged -= HandlePathNumberChanged;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ToggleMusic(MainManager.Instance.PathNumber);
    }

    private void HandlePathNumberChanged(int newPathNumber)
    {
        ToggleMusic(newPathNumber);
    }

    private void ToggleMusic(int number)
    {
        switch (number)
        {
            case 4:
                audioSource.clip = source1;
                audioSource.Play();
                break;
            case 6:
                audioSource.clip = source2;
                audioSource.Play();
                break;
            case 8:
                audioSource.Play();
                audioSource.clip = source3;
                break;
        }
    }
}
