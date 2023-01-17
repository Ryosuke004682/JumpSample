using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySample1 : MonoBehaviour
{

    [SerializeField]
    public Vector3 velocity;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(velocity * Physics.gravity.y , ForceMode.Impulse);
    }

}
