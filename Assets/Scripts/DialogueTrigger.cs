using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBoxObject;
    public GameObject nextButton;
    public GameObject dialogueToDisable;
    private EventSystem eventSystem;


  void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

   private void OnTriggerEnter2D()
    {
        dialogueBoxObject.SetActive(true);
        eventSystem.SetSelectedGameObject(nextButton, null);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, dialogueToDisable);
    }

    private void OnTriggerExit2D()
    {
        dialogueBoxObject.SetActive(false);
    }
}
