using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coc_effect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Move player = other.gameObject.GetComponent<Move>();

        if (player != null)
        {

            player.SpeedEffect();
            Debug.Log("Grosse vitesse");
        }

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);
        }


    }

}
