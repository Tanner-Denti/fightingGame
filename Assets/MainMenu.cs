using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HoverSound()
    {
        mySounds.PlayOneShot(hoverSound);
    }

    public void ClickSound()
    {
        mySounds.PlayOneShot(clickSound);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
