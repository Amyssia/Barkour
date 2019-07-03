using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    
    public static GameManager s_Singleton;

    public GameObject[] barSelection;
    public GameObject defaultBar;
    int indexBarSelection;
    float nextPos = 0f;
    GameObject barToSpawn;
    GameObject barToDestroy;
    GameObject nextBar;
    
    public GameObject ObjectToSpawn;
    private GameObject ObjectToDestroy;
    public GameObject FirstBar;
    private GameObject newBar;

    private float newPosition = 0f;
    
    // Singleton

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

    // Functions
    
    public void SpawnBar()
    {
        indexBarSelection = Random.Range(0, barSelection.Length);
        barToSpawn = barSelection[indexBarSelection];

        if (ObjectToDestroy == null)
        {
            barToDestroy = defaultBar;
            nextBar = Instantiate(barToSpawn, new Vector3(0, 0, newPosition + 20f), transform.rotation);
            nextPos = nextBar.transform.position.z;
            return;
        }

        Destroy(barToDestroy);
        barToDestroy = nextBar;
        nextBar = Instantiate(barToSpawn, new Vector3(0, 0, newPosition + 20f), transform.rotation);
        nextPos = nextBar.transform.position.z;
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
    }
}
