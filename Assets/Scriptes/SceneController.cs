using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RestertLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
