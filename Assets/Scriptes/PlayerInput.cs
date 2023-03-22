using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsBlocked { get; set; } = false;
    bool isGameStarted = false;

    public event Action onStartPlay;

    public float GetInput()
    {
        if (IsBlocked)
        {
            return 0;
        }

        if (Input.GetMouseButton(0))
        {
            StartPlay();
            return Input.GetAxis("Mouse X");
        }
        return 0;
    }

    void StartPlay()
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
            onStartPlay?.Invoke();
        }
    }
}
