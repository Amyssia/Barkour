using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateBar : MonoBehaviour {

    public GameObject ObjectToSpawn;


    private GameObject newBar;
    private float newPosition = 0;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            DeclencheBar();
            Debug.Log("Instantiate");
        }
    }

    

    void  DeclencheBar()
    {
        
          newBar= Instantiate(ObjectToSpawn, new Vector3(0,0,20), transform.rotation);
          newPosition = newBar.transform.position.z;
      
            Debug.Log("Bar apparait");
        
        
    }
    
}
