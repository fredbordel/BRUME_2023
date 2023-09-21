using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBoxObject;
    public GameObject nextButton;
    private EventSystem eventSystem;


void Start()
    {
        foreach(string gameObjectName in MainManager.Instance.DisabledDialogueList)
        {
            if (gameObjectName == gameObject.name)
            {
                gameObject.SetActive(false);
            }
        }
    }

  void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

   private void OnTriggerEnter2D()
    {
        dialogueBoxObject.SetActive(true);
        eventSystem.SetSelectedGameObject(nextButton, null);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject);
    }

    private void OnTriggerExit2D()
    {
        dialogueBoxObject.SetActive(false);
    }
}
