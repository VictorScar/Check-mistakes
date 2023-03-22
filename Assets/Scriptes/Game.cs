using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject collectPoint;
    [SerializeField] Camera gameCamera;
    [SerializeField] CrystalAnimator crystalAnimator;

    public static Game Instance { get; set; }
    public GameObject CollectPoint { get => collectPoint; set => collectPoint = value; }
    public Camera GameCamera { get => gameCamera; set => gameCamera = value; }
    public CrystalAnimator CrystalAnimator { get => crystalAnimator; }

    void Awake()
    {
        Instance = this;
    }

}
