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
    }

    void OnTriggerEnter2D()
    {
        MainManager.Instance.NumOfFireOut += 1;
        if (IsObjectWithVideo)
        {
            videoDialogueAnimator.SetTrigger("isOpen");
            saveObjectSound.Play();
            PlayVideo();
        }
        else
        {
            StartCoroutine(SlowlyHideFire());
        }
    }

    void PlayVideo()
    {
        videoPlayer.targetTexture.Release();
        IsObjectSaved = true;
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }

    private IEnumerator SlowlyHideFire()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
        Color startColor = spriteRenderers.Length > 0 ? spriteRenderers[0].color : Color.white;

        float fadeDuration = 3.5f;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;

            foreach (var spriteRenderer in spriteRenderers)
            {
                Color newColor = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0f, t));
                spriteRenderer.color = newColor;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        }

        IsObjectSaved = true;
        gameObject.SetActive(false);
    }
}
