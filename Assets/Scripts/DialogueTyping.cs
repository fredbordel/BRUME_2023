using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class DialogueTyping : MonoBehaviour
{

public TextMeshProUGUI textComponent;
public float textSpeed;
// public LocalizedString[] LoaclizedSetences;

private int index;
    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Debug.Log("HELLO " + textComponent.text);
        foreach (char c in textComponent.text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
