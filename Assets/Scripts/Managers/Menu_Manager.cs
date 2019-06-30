using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    // Variables

    public AudioSource audioSRC;

    public AudioClip hoverSFX;
    public AudioClip clickSFX;

    public string PlayScene;

    public GameObject creditsPanel;
    public GameObject optionsPanel;

    // Buttons Sounds

    public void OnHoverButtons()
    {
        audioSRC.clip = hoverSFX;
        audioSRC.Play();
    }

    public void OnClickButtons()
    {
        audioSRC.clip = clickSFX;
        audioSRC.Play();
    }

    // Buttons

    public void OnClickPlay()
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void OnClickOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OnClickBackCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void OnClickBackOptions()
    {
        optionsPanel.SetActive(false);
    }
}
