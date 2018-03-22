using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public float LastTimeScale;
    public GameObject PausePanel;
    public GameObject EndPanel;
    public string PlayScene;
    public string MenusScene;

    public Move hero;

    public GameObject go;
    public GameObject Instructions;


    public Animator Anim;
    
    


    // Use this for initialization
    void Start()
    {
        Anim.speed = 0;
        PausePanel.SetActive(false);
        EndPanel.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
        LireTuto();

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

    public void OnClickExitMenus()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MenusScene);
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
    public void ToggleEnd()
    {
        if (EndPanel.activeSelf)
        {
            EndPanel.SetActive(false);
        }
        else if (!EndPanel.activeSelf)
        {
            EndPanel.SetActive(true);
        }

    }

    public void LireTuto()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
          
            Instructions.SetActive(false);
            Anim.speed = 1;
            go.SetActive(true);
        }
    }
    

   public void LancerJeu()
    {

        hero.DepartBiere();
        go.SetActive(false);
        
    }

 


}
