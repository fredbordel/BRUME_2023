using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public bool isDialogueDestroyed;
    public GameObject dialogueToDestroy;
    private GameObject byeDialogue;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);


        byeDialogue = dialogueToDestroy;
    }

    private void Start()
    {
        if (isDialogueDestroyed)
        {
            byeDialogue.SetActive(false);
        }
    }
}
