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
    [SerializeField]
    private Animator videoDialogueAnimator;
    private GameObject nextButton;


    public AudioSource audioSource;
    private GameObject disableThisDialogue;
    // private GameObject dialogueBox;
    private Queue<LocalizedString> sentences;
    [SerializeField]
    private CameraManager camManagerScript;


    void Start()
    {
        sentences = new Queue<LocalizedString>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject dialogueToDisable, bool isDialWithVideo, GameObject _nextButton)
    {
        MainManager.Instance.is3DVideoDialogueFinished = false;

        nextButton = _nextButton;
        nextButton.SetActive(false);

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
            TranslateDialogueName(nameTxt, key);
        }
        else if (videoNameTxt && isDialogueWith3DVideo)
        {
            TranslateDialogueName(videoNameTxt, key);
        }

        StartCoroutine(DisplayTextSlowly(sentence.GetLocalizedString()));
    }

    void EndDialogue()
    {
        if (camManagerScript)
        {
            camManagerScript.OrthoZoomOut();
        }

        MainManager.Instance.is3DVideoDialogueFinished = true;
        StartCoroutine(FadeVolume(0.5f, 1.5f));
        nextButton.SetActive(false);

        if (isDialogueWith3DVideo && MainManager.Instance.is3DVideoFinished)
        {
            videoDialogueAnimator.SetTrigger("isClose");
            MainManager.Instance.IsDialogueOpened = false;
        }
        else if (DialogueBox && !isDialogueWith3DVideo)
        {
            var dialogueAnimator = DialogueBox.GetComponent<Animator>();
            dialogueAnimator.SetTrigger("isDialogBoxClose");
            MainManager.Instance.IsDialogueOpened = false;
        }

        disableThisDialogue.SetActive(false);
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
        nextButton.SetActive(false);

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
        nextButton.SetActive(true);
    }

    private void TranslateDialogueName(TextMeshProUGUI name, string key)
    {
        var en = LocalizationSettings.AvailableLocales.Locales[0];
        var fr = LocalizationSettings.AvailableLocales.Locales[1];

        if (key.Contains("Chien"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Dog" : "Chien";
        }
        else if (key.Contains("Brume"))
        {
            name.text = "Brume";
        }
        else if (key.Contains("Chat"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Cat" : "Chat";
        }
        else if (key.Contains("Journal"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Newspaper" : "Journal";
        }
        else if (key.Contains("Repondeur"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Answering machine" : "Répondeur";
        }
        else if (key.Contains("Livre"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Book" : "Livre";
        }
        else if (key.Contains("Intime"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Personal diary" : "Journal intime";
        }
        else if (key.Contains("Cell"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Cell phone" : "Téléphone";
        }
        else if (key.Contains("Google"))
        {
            name.text = "Google Home";
        }
        else if (key.Contains("Blog"))
        {
            name.text = "mindfulgirl.blog.com";
        }
        else if (key.Contains("Pancarte"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "Sign" : "Pancarte";
        }
        else if (key.Contains("Liste"))
        {
            name.text = LocalizationSettings.SelectedLocale == en ? "“" + "To -do list" + "“" : "“" + "Choses à faire" + "”";
        }
        else
        {
            name.text = key;
        }
    }
}
