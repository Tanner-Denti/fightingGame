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
                GameOver = false;
            }
            else{
                Win();
            }
        }
    }

    public void PlayAgain()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win()
    {
        WinMenuUI.SetActive(true);
        GameOver = true;
    }

    public void LoadMenu()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(menuScene);
    }
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }


}