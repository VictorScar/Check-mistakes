using UnityEngine;
using BansheeGz.BGSpline.Components;

public class TrajectoryMovement : MonoBehaviour
{
    [SerializeField] BGCcCursorChangeLinear controller;
    [SerializeField] PlayerCubesStack cubeDrawer;
    [SerializeField] Finish finish;
    [SerializeField] PlayerInput playerInput;

    [SerializeField] float movementSpeed;

    private void Start()
    {
        if (cubeDrawer != null)
        {
            cubeDrawer.onAllCubesAreOver += StopMovement;
            finish.onPlayerFinished += StopMovement;
        }

        playerInput.onStartPlay += StartMovement;
    }

    void StartMovement()
    {
        controller.Speed = movementSpeed;
        playerInput.onStartPlay -= StartMovement;
    }

    void StopMovement()
    {
        controller.Speed = 0;
    }
}
