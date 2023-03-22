using UnityEngine;

public class PlayerHeightController : MonoBehaviour
{

    [SerializeField] GameObject playerModel;

    [SerializeField] PlayerCubesStack cubeStack;
  
    private void Awake()
    {
        cubeStack.onCubeCountChanged += ChangeHeightPlayer;
    }

    public void ChangeHeightPlayer(int heightLevel)
    {
        if (heightLevel > 0)
        {
            playerModel.transform.position += new Vector3(0, heightLevel, 0);
        }
    }
}
