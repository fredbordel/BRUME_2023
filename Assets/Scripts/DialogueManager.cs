using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    private GameObject dialogueBox;


    private Queue<LocalizedString> sentences;

    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueToDisable)
    {
        StartCoroutine(FadeVolume(0.2f, 1.5f));

        TextBox.SetActive(true);
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
            nameTxt.text = key;
        }

        StartCoroutine(DisplayTextSlowly(sentence.GetLocalizedString()));
    }

    void EndDialogue()
    {
        dialogueBox = GameObject.FindWithTag("dialogBox");

        StartCoroutine(FadeVolume(1, 1.5f));

        TextBox.SetActive(false);
        disableThisDialogue.SetActive(false);
        if (dialogueBox)
        {
            dialogueBox.SetActive(false);
        }

        MainManager.Instance.IsDialogueOpened = false;
        MainManager.Instance.DisabledDialogueList.Add(disableThisDialogue.name);
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

    private IEnumerator DisplayTextSlowly(string sentence)
    {
        dialogueTxt.text = "";

        StringBuilder displayedText = new StringBuilder();

        for (int i = 0; i < sentence.Length; i++)
        {
            // Append the current character to the displayed text
            displayedText.Append(sentence[i]);

            // Check if the length of the displayed text is greater than 75
            if (displayedText.Length > 55)
            {
                // Remove the first character with a delay
                StartCoroutine(RemoveCharacterWithDelay(displayedText));
            }

            dialogueTxt.text = displayedText.ToString();

            yield return new WaitForSecondsRealtime(0.07f);
        }
    }

    private IEnumerator RemoveCharacterWithDelay(StringBuilder text)
    {
        // Delay before removing the first character
        yield return new WaitForSecondsRealtime(0.5f);

        // Remove the first character
        text.Remove(0, 1);

        // Update the UI text
        dialogueTxt.text = text.ToString();
    }
}
