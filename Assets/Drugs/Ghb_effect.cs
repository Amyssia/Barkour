using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghb_effect : MonoBehaviour {

    private void OnTriggerEnter(Collider other) { 
    Move player = other.gameObject.GetComponent<Move>();
    
        if (player != null)
        {

            player.ReverseInputs();
            Debug.Log("Touches inversées");
        }

        if (other.CompareTag("Player"))
        {
           
            Destroy(gameObject);
        }


    }


}
