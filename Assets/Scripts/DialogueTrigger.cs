using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueBoxObject;

   private void OnTriggerEnter2D()
    {
        dialogueBoxObject.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerExit2D()
    {
        dialogueBoxObject.SetActive(false);
    }
}
