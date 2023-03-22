using System;
using System.Collections;
using UnityEngine;

public class PointCrystal : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] float rotationSpeed = 200;
    [SerializeField] float speed = 40;
    
    [SerializeField] Collider crystalCollider;

    CrystalAnimator crystalAnimator;

    public event Action <Vector3> onCrystallCollected;

    public int Points { get => points; }

    IEnumerator Start()
    {
        crystalAnimator = Game.Instance.CrystalAnimator;
        while (true)
        {
            yield return null;
            transform.Rotate(0, 1 * rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void CollectCrystal()
    {
        crystalCollider.enabled = false;
        onCrystallCollected?.Invoke(this.transform.position);
        crystalAnimator.CollectAnimation(transform.position);
        Destroy(gameObject);
        //StartCoroutine(CollectCrystalAnimation());
    }

    //IEnumerator CollectCrystalAnimation()
    //{
    //    while (transform.position != collectPoint.position)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, collectPoint.position, speed * Time.deltaTime);
    //        yield return null;
    //    }
    //    Destroy(gameObject);
    //}
}
