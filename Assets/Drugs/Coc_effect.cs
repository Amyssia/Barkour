using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coc_effect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Move>().SpeedEffect();
            Debug.Log("Rapideeeee !!!");
            Destroy(gameObject);
        }
    }

}
