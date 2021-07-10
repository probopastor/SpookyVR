using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField, Tooltip("The name of the Main Menu scene. ")] private string mainMenuName;

    //[SerializedField, Tooltip("The crosshair. ")] private GameObject crosshair;

    [SerializeField, Tooltip("The pause panel that should activate when the game is paused. ")] private GameObject pausePanel;
    [Tooltip("Handles whether or not the game is paused. ")] private bool isPaused;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new InputMaster();

        Cursor.visible = false;
        //crosshair.SetActive(true);
        pausePanel.SetActive(false);
        isPaused = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(controls.UI.Pause.triggered)
        {
            PauseGame();
        }

        //if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        //{
        //    PauseGame();
        //}
    }

    /// <summary>
    /// Pauses and Unpauses the game. 
    /// </summary>
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;

            //crosshair.SetActive(false);
            pausePanel.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else if (isPaused)
        {
            isPaused = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //crosshair.SetActive(true);
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Restarts the current scene. 
    /// </summary>
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Sends the player to the main menu. 
    /// </summary>
    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuName);
    }

    /// <summary>
    /// Gets the pause status of the game. 
    /// </summary>
    /// <returns>True if the game is paused, false otherwise. </returns>
    public bool GetPausedStatus()
    {
        return isPaused;
    }
}
