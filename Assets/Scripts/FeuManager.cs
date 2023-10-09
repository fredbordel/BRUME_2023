using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FeuManager : MonoBehaviour
{

    private void OnEnable()
    {
        MainManager.Instance.PathNumberChanged += HandlePathNumberChanged;
    }

    private void OnDisable()
    {
        MainManager.Instance.PathNumberChanged -= HandlePathNumberChanged;
    }
    void Start()
    {
        ToggleObjects(MainManager.Instance.PathNumber);
    }

    private void HandlePathNumberChanged(int newPathNumber)
    {
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
                if (gameObject.name == "feu_group_5")
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
