using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FeuManager : MonoBehaviour
{
    void Start()
    {
        MainManager.Instance.PathNumberChanged += HandlePathNumberChanged;
        ToggleObjects(MainManager.Instance.PathNumber);
    }
    private void OnDestroy()
    {
        if (!MainManager.Instance) return;
        MainManager.Instance.PathNumberChanged -= HandlePathNumberChanged;
    }

    private void HandlePathNumberChanged(int newPathNumber)
    {
        if (!MainManager.Instance) return;
        ToggleObjects(newPathNumber);
    }

    private void ToggleObjects(int number)
    {
        switch (number)
        {
            case 1:
                if (gameObject.name == "feu_group_1" || gameObject.name == "feu_group_2")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 2:
                if (gameObject.name == "feu_group_1" || gameObject.name == "feu_group_3")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 3:
                if (gameObject.name == "feu_group_2" || gameObject.name == "feu_group_4")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 4:
                if (gameObject.name == "feu_group_2" || gameObject.name == "feu_group_1" || gameObject.name == "feu_group_3")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 5:
                if (gameObject.name == "feu_group_4" || gameObject.name == "feu_group_2" || gameObject.name == "feu_group_5")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 6:
                if (gameObject.name == "feu_group_6" || gameObject.name == "feu_group_7")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 7:
                if (gameObject.name == "feu_group_5" || gameObject.name == "feu_group_8")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 8:
                if (gameObject.name == "feu_group_5" || gameObject.name == "feu_group_9")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
            case 9:
                if (gameObject.name == "feu_group_8")
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
