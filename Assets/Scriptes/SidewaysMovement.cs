using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMovement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerCubesStack playerCubesStack;
    [SerializeField] Finish finish;

    [SerializeField] float speed = 1f;
    [SerializeField] float limit = 2.5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCubesStack.onAllCubesAreOver += BlockInput;
        finish.onPlayerFinished += BlockInput;
    }

    void Update()
    {
        MoveSideway();
    }

    void MoveSideway()
    {

        rb.AddRelativeForce(Vector3.right * playerInput.GetInput() * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        limitationOfMovements();
    }

    void limitationOfMovements()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -limit, limit), transform.localPosition.y, 0);
    }

    void BlockInput()
    {
        playerInput.IsBlocked = true;
    }
}
