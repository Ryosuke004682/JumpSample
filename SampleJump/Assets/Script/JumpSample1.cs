using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpSample1 : MonoBehaviour
{
    Rigidbody rb;
    bool groundCheck = false;
    public float jumpPower;
    public float jumpCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if(jumpCount < 2 && Input.GetKey(KeyCode.Space))
        {
            groundCheck = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(0 , jumpPower , 0);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
            jumpCount = 0;
        }
    }

}
