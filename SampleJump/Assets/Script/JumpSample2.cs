using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSample2 : MonoBehaviour
{
    private Rigidbody rb;
    public int upForce;
    public float distance;
    public bool jumpCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 rayPosition = transform.position + Vector3.zero;

        Ray ray = new Ray(rayPosition , Vector3.down);
        bool isGround = Physics.Raycast(ray , distance);

        Debug.DrawRay(rayPosition, Vector3.down * distance , Color.red);


        if(isGround)
        {
            jumpCount = true;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(isGround)
                rb.AddForce(new Vector3(0 , upForce , 0));
            else
            {
                if (jumpCount)
                    rb.AddForce(new Vector3(0 , upForce , 0));
                jumpCount = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumpCount = false;
        }
    }

}
