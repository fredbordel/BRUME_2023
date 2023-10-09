using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.PathNumber >= 3)
        {
            gameObject.SetActive(false);
        }
    }
}
