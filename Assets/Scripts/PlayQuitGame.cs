using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayQuitGame : MonoBehaviour
{
    [SerializeField]
    private GameObject FR;
    [SerializeField]
    private GameObject EN;
    [SerializeField]
    private GameObject Jouer;
    [SerializeField]
    private GameObject Quitter;
    private EventSystem eventSystem;

    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }
    public void StartGame()
    {
        FR.SetActive(true);
        EN.SetActive(true);
        Jouer.SetActive(false);
        Quitter.SetActive(false);

        eventSystem.SetSelectedGameObject(FR, null);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}
