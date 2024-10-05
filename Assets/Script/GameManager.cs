using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For UI elements including Button

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI; // Assign the Game Over UI GameObject
    public TextMeshProUGUI scoreText; // Assign score text in inspector
    public Button restartButton; // Assign restart button in inspector

    public static GameManager instance;
    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Hide Game Over UI and Restart Button at the start
        HideGameOverUI();
    }

    void Update()
    {
        scoreText.text = "Score: " + score; // Update score display
    }

    public void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void DeathScreen()
    {
        Debug.Log("Entering DeathScreen");
        GameOverUI.SetActive(true); // Show Game Over UI
        restartButton.gameObject.SetActive(true); // Show Restart Button
        Time.timeScale = 0; // Stop the game
        Debug.Log("Game Over!");
    }

    public void RetryGame()
    {
        Debug.Log("Retrying game...");
        score = 0; // Reset score

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Ensure UI is hidden after reload
        HideGameOverUI();

        Time.timeScale = 1; // Resume the game
    }

    private void HideGameOverUI()
    {
        GameOverUI.SetActive(false); // Hide Game Over UI
        restartButton.gameObject.SetActive(false); // Hide Restart Button
    }
}