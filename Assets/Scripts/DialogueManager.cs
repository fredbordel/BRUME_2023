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
    public AudioSource audioSource;
    private GameObject disableThisDialogue;


    private Queue<LocalizedString> sentences;

    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueToDisable)
    {
        StartCoroutine(FadeVolume(0.2f, 1.5f));

        MainManager.Instance.IsDialogueOpened = true;

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
        else if (key.Contains("Brume"))
        {
            nameTxt.text = "Brume";
        }
        else
        {
            nameTxt.text = "";
        }

        dialogueTxt.text = sentence.GetLocalizedString();
    }

    void EndDialogue()
    {
        StartCoroutine(FadeVolume(1, 1.5f));

        TextBox.SetActive(false);

        MainManager.Instance.IsDialogueOpened = false;
        MainManager.Instance.DisabledDialogueList.Add(disableThisDialogue.name);

        disableThisDialogue.SetActive(false);
    }

    private IEnumerator FadeVolume(float targetVolume, float duration)
    {
        float startVolume = audioSource.volume;
        float currentTime = 0.0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
