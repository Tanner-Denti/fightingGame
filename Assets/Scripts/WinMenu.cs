using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
    public static bool GameOver = false;

    public GameObject WinMenuUI;
    public GameObject playerOne;
    public GameObject playerTwo;

    protected string menuScene = "TitleScene";
 
    // Update is called once per frame
    void Update()
    {
        // Checks to see if the gameObjects for the players are available
        if (playerOne == null || playerTwo == null)
        {
            if(GameOver)
            {    
                GameOver = false;
            }
            else{
                Win();
            }
        }
    }

    // Resets the scene
    public void PlayAgain()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Pulls up a win menu
    void Win()
    {
        WinMenuUI.SetActive(true);
        GameOver = true;
    }

    // Pulls up the main menu
    public void LoadMenu()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(menuScene);
    }

    // Quits the game
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }


}