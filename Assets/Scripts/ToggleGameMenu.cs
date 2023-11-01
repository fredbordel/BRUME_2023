using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.EventSystems;
using UnityEngine;

public class ToggleGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private GameObject menuFirstButton;
    private EventSystem eventSystem;

    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }
    void Start()
    {
        gameMenu.SetActive(false);
    }

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
                eventSystem.SetSelectedGameObject(menuFirstButton, null);
            }
        }
    }

    // private void Awake()
    // {
    //     if (Instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     Instance = this;
    //     DontDestroyOnLoad(gameObject);
    // }

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

