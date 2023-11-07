using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToggleGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject gameMenu;
    [SerializeField]
    private GameObject menuFirstButton;
    private EventSystem eventSystem;
    private PlayerInput playerInput;
    private InputAction menuOpenCloseAction;

    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
    }
    void Start()
    {
        gameMenu.SetActive(false);
    }

    void Update()
    {
        if (menuOpenCloseAction.WasPressedThisFrame())
        {
            if (gameMenu.activeSelf)
            {
                gameMenu.SetActive(false);
                MainManager.Instance.IsDialogueOpened = false;
            }
            else if (!gameMenu.activeSelf && !MainManager.Instance.IsDialogueOpened)
            {
                gameMenu.SetActive(true);
                eventSystem.SetSelectedGameObject(menuFirstButton, null);
                MainManager.Instance.IsDialogueOpened = true;
            }
        }
    }

    public void ContinueGame()
    {
        gameMenu.SetActive(false);
        MainManager.Instance.IsDialogueOpened = false;
    }

    public void QuitGame()
    {
        MainManager.DestroyInstance();
        SceneManager.LoadScene("MENU");
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

