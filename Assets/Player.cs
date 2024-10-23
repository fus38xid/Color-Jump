using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f; // Jump force
    public Rigidbody2D rb; // Rigidbody reference
    public SpriteRenderer sr; // Sprite renderer

    public string currentColor; // Current color
    public Color colorCyan; // Cyan color
    public Color colorYellow; // Yellow color
    public Color colorMagenta; // Magenta color
    public Color colorPink; // Pink color

    private Camera mainCamera; // Main camera
    private bool hasStarted = false; // Game started flag

    public GameObject startText; // Start text
    public GameObject scoreText; // Score text
    public int score = 0; // Player score

    public GameObject hscoreText; // High score text
    private int highscore; // High score

    void Start()
    {
        SetRandomColor(); // Set random color
        mainCamera = Camera.main; // Get main camera
        rb.velocity = Vector2.zero; // Reset velocity
        rb.isKinematic = true; // Freeze movement

        if (startText != null) // Check start text
        {
            startText.gameObject.SetActive(true); // Show start text
            Debug.Log("Showing start text"); // Log message
        }

        highscore = PlayerPrefs.GetInt("HighScore", 0); // Load high score
        UpdateScoreText(); // Update score display
        UpdateHighscoreText(); // Update high score display
    }

    void Update()
    {
        if (!hasStarted && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))) // Check input
        {
            hasStarted = true; // Set started
            rb.isKinematic = false; // Allow movement
            rb.velocity = Vector2.up * jumpForce; // Apply jump force

            if (startText != null) // Check start text
            {
                startText.gameObject.SetActive(false); // Hide start text
                Debug.Log("Game started, start text hidden..."); // Log message
            }
        }

        if (hasStarted && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))) // Check input
        {
            rb.velocity = Vector2.up * jumpForce; // Apply jump force
        }

        if (hasStarted && IsOutOfView()) // Check out of view
        {
            Debug.Log("Player is out of camera view. Restarting game..."); // Log message
            RestartGame(); // Restart game
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger") // Check color changer
        {
            SetRandomColor(); // Set random color
            Destroy(col.gameObject); // Destroy color changer

            score++; // Increment score

            if (score > highscore) // Check high score
            {
                highscore = score; // Update high score
                PlayerPrefs.SetInt("HighScore", highscore); // Save high score
                UpdateHighscoreText(); // Update high score display
            }

            UpdateScoreText(); // Update score display

            return; // Exit method
        }

        if (col.tag != currentColor) // Check color mismatch
        {
            Debug.Log("GAME OVER!"); // Log game over
            RestartGame(); // Restart game
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4); // Random index
        switch (index) // Select color
        {
            case 0:
                currentColor = "cyan"; // Set cyan
                sr.color = colorCyan; // Apply cyan
                break;
            case 1:
                currentColor = "yellow"; // Set yellow
                sr.color = colorYellow; // Apply yellow
                break;
            case 2:
                currentColor = "magenta"; // Set magenta
                sr.color = colorMagenta; // Apply magenta
                break;
            case 3:
                currentColor = "pink"; // Set pink
                sr.color = colorPink; // Apply pink
                break;
        }
    }

    void UpdateScoreText()
    {
        TextMeshProUGUI textComponent = scoreText.GetComponent<TextMeshProUGUI>(); // Get score text
        if (textComponent != null) // Check text component
        {
            textComponent.text = "Score: " + score.ToString(); // Update score
        }
        else
        {
            Debug.LogError("scoreText does not have a TextMeshProUGUI component!"); // Log error
        }
    }

    void UpdateHighscoreText()
    {
        TextMeshProUGUI textComponent = hscoreText.GetComponent<TextMeshProUGUI>(); // Get high score text
        if (textComponent != null) // Check text component
        {
            textComponent.text = "High Score: " + highscore.ToString(); // Update high score
        }
        else
        {
            Debug.LogError("hscoreText does not have a TextMeshProUGUI component!"); // Log error
        }
    }

    bool IsOutOfView()
    {
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position); // Get screen position
        return screenPosition.y < 0 || screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y > 1; // Check visibility
    }

    void RestartGame()
    {
        score = 0; // Reset score
        UpdateScoreText(); // Update score display

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
    }
}
