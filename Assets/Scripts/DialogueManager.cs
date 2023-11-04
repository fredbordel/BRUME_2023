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
    [SerializeField]
    private TextMeshProUGUI nameTxt;

    [SerializeField]
    private TextMeshProUGUI dialogueTxt;

    [SerializeField]
    private GameObject DialogueBox;

    [SerializeField]
    private GameObject VideoDialogueBox;

    [SerializeField]
    private TextMeshProUGUI videoNameTxt;

    [SerializeField]
    private TextMeshProUGUI videoDialogueTxt;
    private Dialogue dialogue;
    private bool isDialogueWith3DVideo;


    public AudioSource audioSource;
    private GameObject disableThisDialogue;
    // private GameObject dialogueBox;


    private Queue<LocalizedString> sentences;

    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueToDisable, bool isDialWithVideo)
    {
        isDialogueWith3DVideo = isDialWithVideo;

        StartCoroutine(FadeVolume(0.1f, 1.5f));

        if (isDialWithVideo)
        {
            VideoDialogueBox.SetActive(true);
        }
        else
        {
            DialogueBox.SetActive(true);
        }

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

        if (nameTxt && !isDialogueWith3DVideo)
        {

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
        }
        else if (videoNameTxt && isDialogueWith3DVideo)
        {
            if (key.Contains("Chien"))
            {
                videoNameTxt.text = "Chien";
            }
            else if (key.Contains("Brume"))
            {
                videoNameTxt.text = "Brume";
            }
            else
            {
                videoNameTxt.text = key;
            }
        }

        StartCoroutine(DisplayTextSlowly(sentence.GetLocalizedString()));
    }

    void EndDialogue()
    {
        StartCoroutine(FadeVolume(0.5f, 1.5f));

        if (isDialogueWith3DVideo)
        {
            VideoDialogueBox.SetActive(false);
        }
        else
        {
            DialogueBox.SetActive(false);
        }

        disableThisDialogue.SetActive(false);

        if (DialogueBox)
        {
            DialogueBox.SetActive(false);
        }

        if (VideoDialogueBox)
        {
            VideoDialogueBox.SetActive(false);
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
        if (dialogueTxt && !isDialogueWith3DVideo)
        {
            dialogueTxt.text = "";
        }
        else if (videoDialogueTxt && isDialogueWith3DVideo)
        {
            videoDialogueTxt.text = "";
        }

        StringBuilder displayedText = new StringBuilder();

        for (int i = 0; i < sentence.Length; i++)
        {
            displayedText.Append(sentence[i]);

            if (dialogueTxt && !isDialogueWith3DVideo)
            {
                dialogueTxt.text = displayedText.ToString();

            }
            else if (videoDialogueTxt && isDialogueWith3DVideo)
            {
                videoDialogueTxt.text = displayedText.ToString();

            }

            yield return new WaitForSecondsRealtime(0.03f);
        }
    }
}
