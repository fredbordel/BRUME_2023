using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI dialogueTxt;
    public Dialogue dialogue;
    public GameObject TextBox;

    
    private Queue<LocalizedString> sentences;
    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameTxt.text = dialogue.name;

        sentences.Clear();

        foreach (LocalizedString sentence in dialogue.localizedSentences)
        {
            // string sentence = strings.GetLocalizedString();
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
        dialogueTxt.text = sentence.GetLocalizedString();
    }

    void EndDialogue()
    {
        TextBox.SetActive(false);
    }
}
