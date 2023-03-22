using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gamePanel;
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text gameMessage;
    [SerializeField] Button restartButton;

    [SerializeField] GameState gameState;
    [SerializeField] SceneController sceneController;
    
    private void Start()
    {
        gameState.onGameResultObtained += ShowGamePanel;
        restartButton.onClick.AddListener(sceneController.RestertLevel);
    }

    void ShowGamePanel(string message, int score)
    {
        gamePanel.SetActive(true);
        UpdateGameMessage(message);
        UpdateScoreText(score);
    }

    void UpdateGameMessage(string message)
    {
        gameMessage.text = message;
    }

    void UpdateScoreText(int score)
    {
        scoreUI.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveListener(sceneController.RestertLevel);
    }
}
