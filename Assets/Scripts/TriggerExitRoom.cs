using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerExitRoom : MonoBehaviour
{
    private FadeInOut fade;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    void OnTriggerEnter2D()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("feu");
        if (objs.Length == 0)
        {
            if (MainManager.Instance)
            {
                MainManager.Instance.CurrentScene = "nouvelle_map";
            }
            MainManager.Instance.PathNumber += 1;
            StartCoroutine(_ChangeScene());
        }
    }

    public IEnumerator _ChangeScene()
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 1.5f;
            yield return null;
        }

        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("nouvelle_map");
    }

}
