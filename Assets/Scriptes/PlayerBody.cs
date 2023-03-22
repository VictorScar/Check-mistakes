using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] PlayerCubesStack playerCubesStack;

    private void Start()
    {
        playerCubesStack.onAllCubesAreOver += FallPlayer;
    }
    void FallPlayer()
    {
        rb.constraints = 0;
        rb.isKinematic = false;
    }

    private void OnDestroy()
    {
        playerCubesStack.onAllCubesAreOver -= FallPlayer;
    }
}
