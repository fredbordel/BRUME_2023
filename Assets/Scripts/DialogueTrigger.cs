using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject TextBox;

   private void OnTriggerEnter2D()
    {
        TextBox.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerExit2D()
    {
        TextBox.SetActive(false);
    }
}
