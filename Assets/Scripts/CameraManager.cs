using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  private float defaultOrthoSize;
  private CinemachineVirtualCamera virtualCam;

  public void OrthoZoomIn(CinemachineVirtualCamera vmCam)
  {
    virtualCam = vmCam;
    defaultOrthoSize = virtualCam.m_Lens.OrthographicSize;
    // vmCam.m_Lens.OrthographicSize = 2;
    // vmCam.m_Lens.OrthographicSize = Mathf.Lerp(vmCam.m_Lens.OrthographicSize, 2, Time.deltaTime * 0.01f);
    StartCoroutine(SlowlyZoom());
  }

  public void OrthoZoomOut()
  {
    virtualCam.m_Lens.OrthographicSize = defaultOrthoSize;
  }

  private IEnumerator SlowlyZoom()
  {
    float currentTime = 0.0f;

    while (currentTime < 2)
    {
      currentTime += Time.deltaTime;
      virtualCam.m_Lens.OrthographicSize = Mathf.Lerp(defaultOrthoSize, 2, currentTime / 2);
      yield return null;
    }

    virtualCam.m_Lens.OrthographicSize = 2;
  }

}