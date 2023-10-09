using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChooseLang : MonoBehaviour
{
    public void SelectFr()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        SceneManager.LoadScene("nouvelle_map");
    }

    public void SelectEn()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        SceneManager.LoadScene("nouvelle_map");
    }
}
