using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ScoreManager scoreManager; // Reference to ScoreManager

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager
    }

    public void RestartGame()
    {
        scoreManager.ResetScore(); // Reset the score
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the scene
    }
}
