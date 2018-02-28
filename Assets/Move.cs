using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Move : MonoBehaviour
{
    public float Speed = 10f;
    public float SpeedSaut = 5f;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
    }

    void Update()
    {
        Vector3 newPosition = transform.position + Speed * transform.forward * Time.deltaTime;
        _rigidbody.MovePosition(newPosition);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + Speed * transform.right * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position - Speed * transform.right * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 newPosition = transform.position + SpeedSaut * transform.up * Time.deltaTime;
            _rigidbody.MovePosition(newPosition);
        }
    }
}
