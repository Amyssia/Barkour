using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    // Variables

    public AudioSource audioSRC;
    public AudioClip hoverSFX;
    public AudioClip clickSFX;
    
    string playScene;
    public string sceneFrancais;
    public string sceneEnglish;

    public GameObject frenchMenu;
    public GameObject frenchCredits;
    public GameObject frenchBackButton;
    public GameObject frenchBGOptions;

    public GameObject creditsPanel;
    public GameObject optionsPanel;
    
    bool languageEnglish = true;
    
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

    // Toggle

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ToggleLanguageEnglish()
    {
        if (languageEnglish == true)
        {
            languageEnglish = false;
            CheckLanguage();
        }
        else
        {
            languageEnglish = true;
            CheckLanguage();
        }
    }

    // Functions

    public void CheckLanguage()
    {
        if (languageEnglish == true)
        {
            playScene = sceneEnglish;
            frenchMenu.SetActive(false);
            frenchCredits.SetActive(false);
            frenchBackButton.SetActive(false);
            frenchBGOptions.SetActive(false);
        }
        else
        {
            playScene = sceneFrancais;
            frenchMenu.SetActive(true);
            frenchCredits.SetActive(true);
            frenchBackButton.SetActive(true);
            frenchBGOptions.SetActive(true);
        }
    }

    // Buttons

    public void OnClickPlay()
    {
        SceneManager.LoadScene(playScene);
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
