using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class TriggerDialogue : MonoBehaviour
{

public GameObject TextBox;
public string entryName;

[SerializeField]
LocalizeStringEvent statusTextBehaviour;

     private void OnTriggerEnter2D()
    {
        TextBox.SetActive(true);
    }

    private void OnTriggerExit2D()
    {
        statusTextBehaviour.StringReference.TableEntryReference = entryName;
    }
}
