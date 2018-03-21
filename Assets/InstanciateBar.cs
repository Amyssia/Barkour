using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateBar : MonoBehaviour

{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))

        {
            GameManager.s_Singleton.DeclencheBar();

            Debug.Log("Instantiate");
        }
    }
    
}
