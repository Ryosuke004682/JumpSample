using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSample3 : MonoBehaviour
{
    public const int _jumpCount = 2;
    public float _jumpForce = 300;

    private int _jumpCounter = 0;
    private bool isJump = false;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if(_jumpCounter < _jumpCount && Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(isJump)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpCounter++;

            isJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _jumpCounter = 0;
        }
    }

}
