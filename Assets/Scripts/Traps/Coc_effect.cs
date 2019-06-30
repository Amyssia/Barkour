using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coc_effect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().SpeedEffect();
            Destroy(gameObject);
        }
    }
}
