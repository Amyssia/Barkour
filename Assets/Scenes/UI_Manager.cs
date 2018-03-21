using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public float LastTimeScale;
    public GameObject PausePanel;
    public string PlayScene;

    // Use this for initialization
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void OnClickResume()
    {
        TogglePause();
    }

    public void OnClickReload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(PlayScene);
        
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if(PausePanel.activeSelf)
        {
            PausePanel.SetActive(false);
            Time.timeScale = LastTimeScale;
        }
        else if (!PausePanel.activeSelf)
        {
            LastTimeScale = Time.timeScale;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }

    }



}
