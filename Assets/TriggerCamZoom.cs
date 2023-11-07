using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggerCamZoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vmCam;
    private float defaultCamOrthoSize;

    void Start()
    {
        defaultCamOrthoSize = vmCam.m_Lens.OrthographicSize;
    }
    private void OnTriggerEnter2D()
    {
        OrthoZoomIn();
    }

    private void OnDisable()
    {
        // OrthoZoomOut();
        vmCam.m_Lens.OrthographicSize = defaultCamOrthoSize;
    }

    public void OrthoZoomIn()
    {
        StartCoroutine(SlowlyZoom(2, 1));
    }

    public void OrthoZoomOut()
    {
        StartCoroutine(SlowlyZoom(defaultCamOrthoSize, 1));
    }

    private IEnumerator SlowlyZoom(float target, float duration)
    {
        float currentTime = 0.0f;

        while (currentTime < duration && gameObject)
        {
            currentTime += Time.deltaTime;
            vmCam.m_Lens.OrthographicSize = Mathf.Lerp(defaultCamOrthoSize, target, currentTime / duration);
            yield return null;
        }

        vmCam.m_Lens.OrthographicSize = target;
    }
}
