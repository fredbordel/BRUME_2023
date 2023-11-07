using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  private float defaultOrthoSize;
  [SerializeField]
  private CinemachineVirtualCamera virtualCam;

  private void Start()
  {
    defaultOrthoSize = virtualCam.m_Lens.OrthographicSize;
  }
  public void OrthoZoomIn()
  {
    StartCoroutine(SlowlyZoom(defaultOrthoSize, 3.5f, 1));
  }
  public void OrthoZoomOut()
  {
    StartCoroutine(SlowlyZoom(3.5f, defaultOrthoSize, 1));
  }

  private IEnumerator SlowlyZoom(float start, float target, float duration)
  {
    float currentTime = 0.0f;

    while (currentTime < duration)
    {
      currentTime += Time.deltaTime;
      virtualCam.m_Lens.OrthographicSize = Mathf.Lerp(start, target, currentTime / duration);
      yield return null;
    }

    virtualCam.m_Lens.OrthographicSize = target;
  }

}