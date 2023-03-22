using System;
using UnityEngine;

public class CubeProcessor : MonoBehaviour
{
    public event Action onSurfCubeCollision;
    public event Action<CubeDetector> onObstacleCollision;
    public event Action<CubeDetector> onAbyssCollision;
    public event Action<int> onPointCollision;

    public void DefineTriggerObjectType(GameObject collisionObject, Detector detector)
    {
        LayerMask objectLayer = collisionObject.layer;

        if (objectLayer == LayerMask.NameToLayer("CubeSurf"))
        {
            SurfCubeLogic(collisionObject);
        }
        else if (objectLayer == LayerMask.NameToLayer("Obstacle"))
        {
            if (detector is CubeDetector cubeDetector)
            {
                ObstacleLogic(cubeDetector);
            }
        }
        else if (objectLayer == LayerMask.NameToLayer("Abyss"))
        {
            if (detector is CubeDetector cubeDetector)
            {
                AbyssLogic(cubeDetector);
            }
        }
        else if (objectLayer == LayerMask.NameToLayer("Points"))
        {
            PointCrystal point = collisionObject.GetComponent<PointCrystal>();
            if (point != null)
            {
                CrystallPointLogic(point);
            }
        }
    }

    void SurfCubeLogic(GameObject collisionObject)
    {

        Destroy(collisionObject);
        onSurfCubeCollision?.Invoke();
    }

    void ObstacleLogic(CubeDetector detector)
    {
        onObstacleCollision?.Invoke(detector);
    }
    void AbyssLogic(CubeDetector detector)
    {
        onAbyssCollision?.Invoke(detector);
    }

    void CrystallPointLogic(PointCrystal pointCrystall)
    {
        onPointCollision?.Invoke(pointCrystall.Points);
        pointCrystall.CollectCrystal();
    }
}
