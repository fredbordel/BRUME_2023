using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI dialogueTxt;
    public Dialogue dialogue;
    public GameObject TextBox;
    private GameObject disableThisDialogue;

    
    private Queue<LocalizedString> sentences;

    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueToDisable)
    {
        disableThisDialogue = dialogueToDisable;

        sentences.Clear();

        foreach (LocalizedString sentence in dialogue.localizedSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        LocalizedString sentence = sentences.Dequeue();

        var tableEntry = LocalizationSettings.StringDatabase.GetTableEntry(sentence.TableReference, sentence.TableEntryReference);
        var key = tableEntry.Entry.SharedEntry.Key;

        if (key.Contains("Chien"))
        {
            nameTxt.text = "Chien";
        } 
        else if (key.Contains("Brume")) {
            nameTxt.text = "Brume";
        }
        else {
            nameTxt.text = "";
        }
        
        dialogueTxt.text = sentence.GetLocalizedString();
    }

    void EndDialogue()
    {
        TextBox.SetActive(false);
        if (disableThisDialogue.name == "DialolgueRencontreCollider")
        {
            Debug.Log("hello");
            MainManager.Instance.DialogueRencontreCollider = false;
        }
        disableThisDialogue.SetActive(false);
    }
}
