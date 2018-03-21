using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int nb = 0;

    public static GameManager s_Singleton;

    public GameObject ObjectToSpawn;

    private GameObject ObjectToDestroy;

    public GameObject FirstBar;


    private GameObject newBar;
    private float newPosition = 0f;





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


    public void Start()
    {
        
    }


    public void AjouteNb ()
    {
        nb++;
        Debug.Log(nb);
    }

    public void DeclencheBar()
    {
        if(ObjectToDestroy == null )
        {
            ObjectToDestroy = FirstBar;
            newBar = Instantiate(ObjectToSpawn, new Vector3(0, 0, newPosition + 20f), transform.rotation);
            newPosition = newBar.transform.position.z;
            return;
        }
        Destroy(ObjectToDestroy);
        ObjectToDestroy = newBar;
        newBar = Instantiate(ObjectToSpawn, new Vector3(0, 0, newPosition + 20f), transform.rotation);
        newPosition = newBar.transform.position.z;
        


        Debug.Log("Bar apparait");
    }

}
