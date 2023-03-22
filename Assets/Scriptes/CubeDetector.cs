using System;
using System.Collections;
using UnityEngine;

public class CubeDetector : Detector
{
    //[SerializeField] float delayOfDestruction = 3;
    public event Action<GameObject, CubeDetector> onDetectCubeCollision;

    protected override void OnTriggerEnter(Collider other)
    {
        onDetectCubeCollision?.Invoke(other.gameObject, this);
    }

    public void DestroyCube(float delay = 0)
    {
        StartCoroutine(DestroyCoroutine(delay));
    }

    IEnumerator DestroyCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
