using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText; // Score text
    public GameObject hscoreText; // High score text
    public int score = 0; // Player score
    private int highscore; // High score

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0); // Load high score
        UpdateScoreText();
        UpdateHighscoreText();
    }

    public void AddScore()
    {
        score++; // Increment score

        if (score > highscore) // Check high score
        {
            highscore = score; // Update high score
            PlayerPrefs.SetInt("HighScore", highscore); // Save high score
            UpdateHighscoreText();
        }

        UpdateScoreText(); // Update score display
    }

    public void ResetScore()
    {
        score = 0; // Reset score
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        TextMeshProUGUI textComponent = scoreText.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "Score: " + score.ToString();
        }
    }

    public void UpdateHighscoreText()
    {
        TextMeshProUGUI textComponent = hscoreText.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "High Score: " + highscore.ToString();
        }
    }
}
