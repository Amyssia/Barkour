using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Move : MonoBehaviour
{
    public float Speed = 10f;
    public float SpeedStrafe = 0.1f;
    public float JumpForce = 2f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
    }

    void Update()
    
    {
        Vector3 newPosition = transform.position + Speed * transform.forward * Time.deltaTime;
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("fleche droite");
            newPosition +=  SpeedStrafe * transform.right * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition -=  SpeedStrafe * transform.right * Time.deltaTime;
            
        }
        
        _rigidbody.MovePosition(newPosition);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    public void ReverseInputs()
    {
        
        SpeedStrafe *= -1;
        Debug.Log("c'est inversé");
    }

}
