using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] CubeProcessor cubeProcessor;

    [SerializeField] int points = 0;

    public int Points { get => points; private set => points = value; }

    public event Action<int> onPointsChanged;

    void Start()
    {
        cubeProcessor.onPointCollision += CollectPoints;
    }

    void CollectPoints(int points)
    {
        Points += points;
        onPointsChanged?.Invoke(Points);
    }

    void MultiplyPoints(int multiplier)
    {
        Points *= multiplier;
        onPointsChanged?.Invoke(points);
    }
}
