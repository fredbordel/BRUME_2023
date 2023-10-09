using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine;

public class ToggleGameMenu : MonoBehaviour
{

    public static ToggleGameMenu Instance;
    public GameObject gameMenu;

    void Start()
    {
        gameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeSelf == true)
            {
                gameMenu.SetActive(false);
            }
            else
            {
                gameMenu.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ContinueGame()
    {
        gameMenu.SetActive(false);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }

    public void SelectFr()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    public void SelectEn()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
}

