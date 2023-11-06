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

    [SerializeField]
    private bool isDialogueWithVideo;


    void Start()
    {
        if (MainManager.Instance)
        {
            foreach (string gameObjectName in MainManager.Instance.DisabledDialogueList)
            {
                if (gameObjectName == gameObject.name)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

    private void OnTriggerEnter2D()
    {
        if (!isDialogueWithVideo)
        {
            var dialogueAnimator = dialogueBoxObject.GetComponent<Animator>();
            dialogueAnimator.SetTrigger("isDialogBoxOpen");
        }

        dialogueBoxObject.SetActive(true);
        eventSystem.SetSelectedGameObject(nextButton, null);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject, isDialogueWithVideo, nextButton);
    }
}
