using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // Jump force
    public Rigidbody2D rb; // Rigidbody reference
    public bool hasStarted = false; // Game started flag
    private ScoreManager scoreManager; // Reference to ScoreManager
    private GameManager gameManager; // Reference to GameManager
    public OutOfBoundsChecker boundsChecker; // Out of bounds checker

    private void Start()
    {
        rb.velocity = Vector2.zero; // Reset velocity
        rb.isKinematic = true; // Freeze movement
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
    }

    private void Update()
    {
        if (!hasStarted && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))) // Start game
        {
            StartGame();
        }

        if (hasStarted && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))) // Jump
        {
            Jump();
        }

        // Check if out of bounds
        if (boundsChecker.IsOutOfView(transform))
        {
            gameManager.RestartGame(); // Restart the game if out of bounds
        }
    }

    public void StartGame()
    {
        hasStarted = true;
        rb.isKinematic = false;
        rb.velocity = Vector2.up * jumpForce;
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreTrigger")) // Check if it's a score trigger object
        {
            scoreManager.AddScore(); // Add score
        }
    }
}
