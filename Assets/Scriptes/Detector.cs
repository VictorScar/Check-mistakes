using UnityEngine;

public abstract class Detector : MonoBehaviour
{
    protected abstract void OnTriggerEnter(Collider other);

}
