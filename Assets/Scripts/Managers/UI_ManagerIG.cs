using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ManagerIG : MonoBehaviour
{
    // Variables

    public static UI_ManagerIG s_Singleton;

    public Text distanceText;
    public Text endDistanceText;
    
    // Singleton

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
	
    // Functions

    public void DisplayDistance(float Score) // Show Distance IG
    {
        distanceText.text = "Score: " + Score.ToString("F2");
    }

    public void DisplayEndDistance(float Score) // Show End Distance
    {
        endDistanceText.text = Score.ToString("F2");
    }
}
