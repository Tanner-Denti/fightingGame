using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public float volume;
    public AudioMixer mixer;
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

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }
}
