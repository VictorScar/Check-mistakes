using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action onPlayerFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            onPlayerFinished?.Invoke();
        }
    }
}
