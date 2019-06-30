using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    // Variables

    public float Speed = 10f;
    public float SpeedStrafe = 0.1f;
    public float JumpForce = 5f;
    private float LifeBeer = 100f;
    public GameObject BeerPlayer;
    public bool isGrounded;

    public float Unknow;
    public GameObject UI_Manager;

    private Rigidbody _rigidbody;

    public bool canMove = false;

    // Start

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);

        Unknow = transform.position.z;
        UI_ManagerIG.s_Singleton.DisplayDistance(transform.position.z + (-Unknow));
    }

    // Update

    void Update()
    {
        Vector3 newPosition = transform.position + Speed * transform.forward * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.RightArrow) && canMove == true)
        {
            newPosition +=  SpeedStrafe * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && canMove == true)
        {
            newPosition -=  SpeedStrafe * transform.right * Time.deltaTime;
        }

        _rigidbody.MovePosition(newPosition);
        UI_ManagerIG.s_Singleton.DisplayDistance(transform.position.z + (-Unknow));
        UI_ManagerIG.s_Singleton.DisplayEndDistance(transform.position.z + (-Unknow));
    }

    // Functions
    
    public void DepartBiere()
    {
        Speed = 2f;
    }

    public void SpeedEffect()
    {
        Speed *= 2;
        SpeedStrafe *= 2;
        StartCoroutine("SpeedCooldown");
    }

    IEnumerator SpeedCooldown()
    {
        yield return new WaitForSeconds(3);
        Speed /= 2;
        SpeedStrafe /= 2;
    }
    
    public void ReverseInputs()
    {
        SpeedStrafe *= -1;
        StartCoroutine("ReverseCooldown");
    }

    IEnumerator ReverseCooldown()
    {
        yield return new WaitForSeconds(5f);
        SpeedStrafe *= -1;
    }

    void CollisionEffect()
    {
        LifeBeer -= 49f;

        if(LifeBeer <= 0)
        {
            gameObject.SetActive(false);
            UI_Manager.GetComponent<UI_Manager>().ToggleEnd();
        }

        if (LifeBeer == 51)
        {
            Debug.Log("first collision");
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (LifeBeer == 2)

        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            CollisionEffect();
        }
    }
}
