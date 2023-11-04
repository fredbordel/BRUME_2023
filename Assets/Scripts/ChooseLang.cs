using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChooseLang : MonoBehaviour
{

    private FadeInOut fade;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }
    public void SelectEn()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        StartCoroutine(_ChangeScene());
    }
    public void SelectFr()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        StartCoroutine(_ChangeScene());
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
        SceneManager.LoadScene("intro");
    }
}
