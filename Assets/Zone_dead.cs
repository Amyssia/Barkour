using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_dead : MonoBehaviour {

    public Transform pinte;

    private Vector3 tmpPos;

    // Use this for initialization
    void Start () {
        tmpPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        

        tmpPos.z = pinte.position.z;

        transform.position = tmpPos;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("It's over");
            Time.timeScale = 0;
        }
    }
}
