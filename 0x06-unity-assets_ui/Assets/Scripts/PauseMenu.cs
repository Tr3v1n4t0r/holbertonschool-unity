using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;    // Boolean used to designate whether or not the game is paused

    public GameObject pauseMenuUI;  // Public object used to display the wanted pause UI

    private int currentLevel;
    public PlayerController pc;
    private Timer t;

    public void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        pc = GetComponent<PlayerController>();
        t = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            // Pauses or unpauses the game when the Escape button is pushed
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Turns off the pause screen
        pauseMenuUI.SetActive(false);
        // Sets the timescale to normal speed
        Time.timeScale = 1f;
        // Sets boolean to false
        GameIsPaused = false;
        // Locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Pauses camera controller
        pc.TogglePause();
    }
    
    void Pause()
    {
        // Turns on the pause screen
        pauseMenuUI.SetActive(true);
        // Sets the timescale to 0 so game objects are unable to move in the background
        Time.timeScale = 0f;
        // Sets boolean to true
        GameIsPaused = true;
        // Unlocks the cursor
        Cursor.lockState = CursorLockMode.None;
        // Pauses camera controller
        pc.TogglePause();
    }

    public void Restart()
    {
        // Turns off the pause screen
        pauseMenuUI.SetActive(false);
        // Sets the timescale to normal speed
        Time.timeScale = 1f;
        // Sets boolean to false
        GameIsPaused = false;
        // Locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Restarts the level
        SceneManager.LoadScene(currentLevel);
    }

    // Funcions that are accessed by in game buttons
    
    public void MainMenu()
    {
        // Sets timescale to normal speed
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
