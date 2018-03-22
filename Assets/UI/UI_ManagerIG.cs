using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ManagerIG : MonoBehaviour {

    public static UI_ManagerIG s_Singleton;

    public Text DistanceText;


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


    
    // Use this for initialization
    void Start () {
		
	}
	
    public void DisplayDistance(float Score)
    {
        DistanceText.text = "Score: " + Score.ToString();
    }
	// Update is called once per frame
	void Update () {


		
	}
}
