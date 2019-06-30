using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghb_effect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        { 
            other.gameObject.GetComponent<Player>().ReverseInputs();
            Destroy(gameObject);
        }
    }
}
