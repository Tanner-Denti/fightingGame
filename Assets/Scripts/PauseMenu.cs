using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    protected string menuScene = "TitleScene";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        // Gets out of the pause menu
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // Loads the pause scene/screen
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // Goes back to the title screen
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }
    public void QuitGame()
    {
        // Quits the game
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
