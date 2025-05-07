using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private RainSpawner rainSpawner;
    [SerializeField] private int gameOverScore = -10;

    private int score;
    private bool isGameOver;

    private void Start()
    {
        Debug.Log("ScoreManager initialized");

        score = 0;
        isGameOver = false;

        UpdateScoreText();

        if (gameOverText) gameOverText.SetActive(false);
        if (tryAgainButton) tryAgainButton.SetActive(false);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        Debug.Log($"Score changed: {score}");

        UpdateScoreText();

        if (score <= gameOverScore)
        {
            HandleGameOver();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText)
            scoreText.text = $"Score: {score}";
    }

    private void HandleGameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");

        if (gameOverText) gameOverText.SetActive(true);
        if (tryAgainButton) tryAgainButton.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
