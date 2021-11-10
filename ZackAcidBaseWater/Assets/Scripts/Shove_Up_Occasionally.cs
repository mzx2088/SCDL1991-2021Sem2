using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shove_Up_Occasionally : MonoBehaviour
{
    public ArticulationBody rb;
    public float speed = 1f;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<ArticulationBody>();
        InvokeRepeating("ShoveLeft", 0.5f, 0.5f);
        velocity = rb.velocity;
    }

    private void FixedUpdate()
    {
        velocity = rb.velocity;
    }

    private void ShoveLeft()
    {
        rb.AddForce(Vector3.left * speed);
    }
}
