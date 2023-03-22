using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera gameCamera;
    [SerializeField] GameObject target;
    [SerializeField] PlayerCubesStack playerCubesStack;

    [SerializeField] float viewStepZ = 1;
    [SerializeField] float viewStepY = 1;
    [SerializeField] float speed = 1;

    Vector3 offset;

    void Start()
    {
        playerCubesStack.onCubeCountChanged += ChangeViewingDistance;

        if (target != null)
        {
            offset = transform.localPosition - target.transform.localPosition;
        }
    }

    void ChangeViewingDistance(int cubeCount)
    {
        var newPosition = transform.localPosition + new Vector3(0, viewStepY * cubeCount, -viewStepZ * cubeCount);
        StartCoroutine(MoveToNewPosition(newPosition, speed));
    }

    IEnumerator MoveToNewPosition(Vector3 newPosition, float speed)
    {
        while (transform.localPosition != newPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, speed * Time.fixedDeltaTime);
            yield return null;
        }
    }
}
