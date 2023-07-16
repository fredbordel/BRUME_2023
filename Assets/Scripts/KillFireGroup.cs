using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFireGroup : MonoBehaviour
{

    public FireGroupState fireGroup;
    public string fireGroupNumber;
    

    private void OnTriggerEnter2D()
    {
        fireGroup.isFireGroupVisibleOne = false;
    }
}
