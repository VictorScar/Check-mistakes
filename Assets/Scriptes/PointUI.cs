using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    [SerializeField] PointsCounter pointsCounter;

    [SerializeField] TMP_Text pointCountUI;

    void Start()
    {
        pointsCounter.onPointsChanged += UpdatePointCountText;
    }

    void UpdatePointCountText(int count)
    {
        pointCountUI.text = $"Points: {count}";
    }

}
