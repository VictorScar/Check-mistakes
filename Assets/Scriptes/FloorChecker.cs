using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : Detector
{
    public event Action<GameObject, Detector> onDetectCollision;

    protected override void OnTriggerEnter(Collider other)
    {
        onDetectCollision?.Invoke(other.gameObject, this);
    }
}
