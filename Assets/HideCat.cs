using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCat : MonoBehaviour
{
    void Start()
    {
        if (MainManager.Instance)
        {
            if (MainManager.Instance.PathNumber >= 3)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
