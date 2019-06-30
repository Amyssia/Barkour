using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_dead : MonoBehaviour
{
    // Variables

    public Transform pinte;
    public GameObject UI_Manager;
    Vector3 tmpPos;

    // Start

    void Start ()
    {
        tmpPos = transform.position;
    }
	
	// Update

	void Update ()
    {
        tmpPos.z = pinte.position.z;
        transform.position = tmpPos;
	}

    // Functions

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            UI_Manager.GetComponent<UI_Manager>().ToggleEnd();
        }
    }
}
