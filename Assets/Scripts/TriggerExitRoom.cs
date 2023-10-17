using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("feu");
        if (objs.Length == 0)
        {
            Debug.Log("GET OUT OF HERE");
        }
        else
        {
            Debug.Log("NOT YET");
        }
    }
}
