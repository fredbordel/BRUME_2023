using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireOutManager : MonoBehaviour
{

  private TextMeshProUGUI textFireOut;

  private void Start()
  {
    textFireOut = gameObject.GetComponent<TextMeshProUGUI>();

    if (MainManager.Instance)
    {
      textFireOut.text = MainManager.Instance.NumOfFireOut.ToString() + "/17";
      MainManager.Instance.NumOfFireOutChanged += HandleFireOut;
    }
  }

  private void HandleFireOut(int newFireOut)
  {
    textFireOut.text = newFireOut.ToString() + "/17";
  }

  private void OnDestroy()
  {
    if (!MainManager.Instance) return;
    MainManager.Instance.NumOfFireOutChanged -= HandleFireOut;
  }


}

