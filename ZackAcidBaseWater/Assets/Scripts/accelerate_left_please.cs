using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate_left_please : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 velocity;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(speed*Vector3.left);
        velocity = rb.velocity;
    }
}
