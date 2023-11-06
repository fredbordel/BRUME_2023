using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = MainManager.Instance.WaterFillAmount;

        MainManager.Instance.PathNumberChanged += HandlePathNumberChanged;
        ReduceWaterLevel(MainManager.Instance.PathNumber);
    }
    private void OnDestroy()
    {
        if (!MainManager.Instance) return;
        MainManager.Instance.WaterFillAmount = image.fillAmount;
        MainManager.Instance.PathNumberChanged -= HandlePathNumberChanged;
    }

    private void HandlePathNumberChanged(int newPathNumber)
    {
        if (!MainManager.Instance) return;
        ReduceWaterLevel(newPathNumber);
    }
    private void ReduceWaterLevel(int number)
    {
        if (number != 1)
        {
            image.fillAmount -= 0.0525f;
        }
    }
}
