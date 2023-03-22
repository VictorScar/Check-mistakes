using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] Finish finish;
    [SerializeField] PlayerCubesStack cubesStack;
    [SerializeField] PointsCounter pointsCounter;

    [SerializeField] string winMessage;
    [SerializeField] string loseMessage;

    public event Action<string, int> onGameResultObtained;

    void Start()
    {
        cubesStack.onAllCubesAreOver += GameLose;
        finish.onPlayerFinished += GameWin;
    }

    void GameLose()
    {
        onGameResultObtained.Invoke(loseMessage, 0);
    }

    void GameWin()
    {
        onGameResultObtained.Invoke(winMessage, pointsCounter.Points);
    }
}
