using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestContinue : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("nouvelle_map");

    }
}
