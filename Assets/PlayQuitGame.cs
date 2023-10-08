using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayQuitGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Menu_EN_FR");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}
