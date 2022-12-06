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


    // [SerializeField] PlayerRespawn respawn;

    
    // Scene ActiveScene = SceneManager.GetActiveScene();

    protected string menuScene = "TitleScene";
    
    // void Start()
    // {
    //     Scene ActiveScene = SceneManager.GetActiveScene().name;
    // }

    // Update is called once per frame
    void Update()
    {
        // lives = GameObject.GetComponent<PlayerRespawn>("playerOne").Lives;
        if (playerOne == null || playerTwo == null)
        {
            if(GameOver)
            {
                // Time.timeScale = 1f;      
                GameOver = false;
            }
            else{
                Win();
            }
            // Win();
        }
        
        // if (lives <= 0)
        // {
        //     if (GameOver)
        //     {
        //         PlayAgain();
        //     }
        //     else
        //     {
        //         Win();
        //     }
        // }
    }

    public void PlayAgain()
    {
        // Time.timeScale = 1f;
        // Debug.Log("Active Scene is '" + ActiveScene.name + "'.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("StageOne");

    }

    void Win()
    {
        WinMenuUI.SetActive(true);
        // Time.timeScale = 0f;
        GameOver = true;
    }

    public void LoadMenu()
    {
        // Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }


}