using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using TMPro;

public class TriggerDialogue : MonoBehaviour
{

public GameObject TextBox;
public string tableName;
public string entryName;
public TextMeshProUGUI textComponent;

// [SerializeField]
// LocalizeStringEvent statusTextBehaviour;

private LocalizedString stringhere;

void Start()
{
    stringhere = new LocalizedString(tableName, entryName);
}

     private void OnTriggerEnter2D()
    {
        TextBox.SetActive(true);
        // statusTextBehaviour.SetEntry(entryName);
        textComponent.text = stringhere.GetLocalizedString();
    }

    // private void OnTriggerExit2D()
    // {
    //     statusTextBehaviour.StringReference.TableEntryReference = entryName;
    // }
}
