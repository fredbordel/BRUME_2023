using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggerCamZoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vmCam;
    [SerializeField]
    private CameraManager camManagerScript;

    private void OnTriggerEnter2D()
    {
        if (camManagerScript)
        {
            camManagerScript.OrthoZoomIn();
        }
    }
}
