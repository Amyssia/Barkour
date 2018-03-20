using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int nb = 0;

    public static GameManager s_Singleton;

 


    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

   

    public void AjouteNb ()
    {
        nb++;
        Debug.Log(nb);
    }

}
