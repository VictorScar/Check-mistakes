using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubesStack : MonoBehaviour
{
    [SerializeField] CubeDetector cubePrefab;
    float cubeDetectorDrawStep;

    [SerializeField] FloorChecker floorChecker;
    [SerializeField] CubeProcessor processor;

    [SerializeField] public List<CubeDetector> cubeDetectors = new List<CubeDetector>();

    public event Action<int> onCubeCountChanged;
    public event Action onAllCubesAreOver;

    private void Start()
    {
        cubeDetectorDrawStep = cubePrefab.transform.localScale.y;
        processor.onSurfCubeCollision += AddCube;
        processor.onObstacleCollision += RemoveCube;
        processor.onAbyssCollision += FallCube;

        foreach (var cube in cubeDetectors)
        {
            cube.onDetectCubeCollision += processor.DefineTriggerObjectType;
        }

        floorChecker.onDetectCollision += processor.DefineTriggerObjectType;
    }

    void AddCube()
    {
        Vector3 currentPosition = cubeDetectors[cubeDetectors.Count - 1].transform.position + new Vector3(0, cubeDetectorDrawStep, 0);

        var cube = Instantiate(cubePrefab, currentPosition, Quaternion.identity, transform);
        cubeDetectors.Add(cube);
        cube.onDetectCubeCollision += processor.DefineTriggerObjectType;
        onCubeCountChanged?.Invoke(1);
    }

    void RemoveCube(CubeDetector cube)
    {
        if (cubeDetectors.Count <= 1)
        {
            onAllCubesAreOver?.Invoke();
            return;
        }

        cubeDetectors.Remove(cube);

        cube.transform.SetParent(null, true);
        cube.onDetectCubeCollision -= processor.DefineTriggerObjectType;

        onCubeCountChanged?.Invoke(-1);
        cube.DestroyCube(3);
    }

    void FallCube(CubeDetector cube)
    {
        if (cubeDetectors.Count <= 1)
        {
            onAllCubesAreOver?.Invoke();
        }

        cubeDetectors.Remove(cube);
        cube.DestroyCube();

    }

    private void OnDestroy()
    {
        processor.onSurfCubeCollision -= AddCube;
        processor.onObstacleCollision -= RemoveCube;
        floorChecker.onDetectCollision -= processor.DefineTriggerObjectType;
        processor.onAbyssCollision -= FallCube;
    }
}
