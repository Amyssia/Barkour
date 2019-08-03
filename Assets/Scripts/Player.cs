using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    // Variables

    AudioSource audioSRC_Player;
    public AudioClip hitSFX;
    public AudioClip hitKillSFX;
    public AudioClip speedSFX;
    public AudioClip ghbSFX;

    public float Speed = 10f;
    public float SpeedStrafe = 0.1f;
    private float LifeBeer = 3f;
    public GameObject BeerPlayer;

    public float Unknow;
    public GameObject UI_Manager;

    private Rigidbody _rigidbody;

    public bool canMove = false;

    // Start

    void Start()
    {
        audioSRC_Player = GetComponent<AudioSource>();

        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);

        Unknow = transform.position.z;
        UI_ManagerIG.s_Singleton.DisplayDistance(transform.position.z + (-Unknow));
    }

    // Update

    void Update()
    {
        Vector3 newPosition = transform.position + Speed * transform.forward * Time.deltaTime; // Move Forward
        
        if (Input.GetKey(KeyCode.RightArrow) && canMove == true) // Input Right
        {
            newPosition +=  SpeedStrafe * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && canMove == true) // Input Left
        {
            newPosition -=  SpeedStrafe * transform.right * Time.deltaTime;
        }

        _rigidbody.MovePosition(newPosition); // Execute Move Forward
        UI_ManagerIG.s_Singleton.DisplayDistance(transform.position.z + (-Unknow)); // Give distance for UI_Manager
    }

    // Functions
    
    public void LaunchBeer() // Start Game
    {
        Speed = 2f;
    }

    public void SpeedEffect() // Cock Effect
    {
        Speed *= 2;
        SpeedStrafe *= 2;
        audioSRC_Player.clip = speedSFX;
        audioSRC_Player.Play();
        StartCoroutine("SpeedCooldown");
    }

    IEnumerator SpeedCooldown() // Cock Cooldown
    {
        yield return new WaitForSeconds(3);
        Speed /= 2;
        SpeedStrafe /= 2;
    }
    
    public void ReverseEffect() // GHB Effect
    {
        SpeedStrafe *= -1;
        audioSRC_Player.clip = ghbSFX;
        audioSRC_Player.Play();
        StartCoroutine("ReverseCooldown");
    }

    IEnumerator ReverseCooldown() // GHB Cooldown
    {
        yield return new WaitForSeconds(5f);
        SpeedStrafe *= -1;
    }

    void CollisionEffect() // Damage To Player
    {
        LifeBeer -= 1f;
        
        if (LifeBeer <= 0)
        {
            audioSRC_Player.clip = hitKillSFX;
            audioSRC_Player.Play();
            gameObject.SetActive(false);
            UI_Manager.GetComponent<UI_Manager>().ToggleEnd();
        }

        if (LifeBeer == 2)
        {
            audioSRC_Player.clip = hitSFX;
            audioSRC_Player.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (LifeBeer == 1)

        {
            audioSRC_Player.clip = hitSFX;
            audioSRC_Player.Play();
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider other) // Collider Detection
    {
        if (other.CompareTag("Obstacle")) // Obstacle
        {
            CollisionEffect();
            Destroy(other);
        }

        if (other.CompareTag("Cock")) // Cock
        {
            SpeedEffect();
            Destroy(other);
        }

        if (other.CompareTag("GHB")) // GHB
        {
            ReverseEffect();
            Destroy(other);
        }
    }
}
