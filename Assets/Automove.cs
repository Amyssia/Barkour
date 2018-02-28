using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automove : MonoBehaviour
{

    void Start()
    {

    }



    public float m_speed = 0.1f;

    void Update()
    {

        // Création d'un nouveau vecteur de déplacement
        Vector3 move = new Vector3();

        // Récupération des touches haut et bas
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.z += 0;
        }
        else
        {
            move.z += m_speed;
        }
       
        

        // On applique le mouvement à l'objet
        transform.position += move;
    }
}
