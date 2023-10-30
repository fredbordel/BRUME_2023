using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayQuitGame : MonoBehaviour
{
    [SerializeField]
    private GameObject FR;

    [SerializeField]
    private GameObject EN;

    public void StartGame()
    {
        FR.SetActive(true);
        EN.SetActive(true);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}
