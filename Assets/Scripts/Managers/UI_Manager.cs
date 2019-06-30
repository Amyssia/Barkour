using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    // Variables

    public AudioSource audioSRC;

    public AudioClip hoverSFX;
    public AudioClip clickSFX;

    public float lastTimeScale;
    public GameObject pausePanel;
    public GameObject endPanel;
    public string menuScene;

    public Player hero;

    public GameObject go;
    public GameObject tutoPanel;
    
    public Animator Anim;
    
    public bool animON = true;

    // Start

    void Start()
    {
        Anim.speed = 0;
        pausePanel.SetActive(false);
        endPanel.SetActive(false);
    }
    
    // Update

    void Update()
    {
        SkipTuto();

        if (Input.GetKeyDown(KeyCode.Escape) && animON == false)
        {
            TogglePause();
        }
    }

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

    public void OnClickResume()
    {
        TogglePause();
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnClickQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuScene);
    }

    // Functions

    public void TogglePause()
    {
        if(pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            Time.timeScale = lastTimeScale;
        }
        else if (!pausePanel.activeSelf)
        {
            lastTimeScale = Time.timeScale;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ToggleEnd()
    {
        if (endPanel.activeSelf)
        {
            endPanel.SetActive(false);
        }
        else if (!endPanel.activeSelf)
        {
            endPanel.SetActive(true);
        }
    }

    public void SkipTuto()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            tutoPanel.SetActive(false);
            Anim.speed = 1;
            go.SetActive(true);
        }
    }
    
   public void LaunchGame()
    {
        animON = false;
        hero.canMove = true;
        hero.DepartBiere();
        go.SetActive(false);
    }
}
