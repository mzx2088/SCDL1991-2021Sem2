using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate_Articulation_Body : MonoBehaviour
{
    private ArticulationBody ab;
    public Vector3 velocity;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        ab = GetComponent<ArticulationBody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ab.AddForce(speed * Vector3.left);
        velocity = ab.velocity;
    }
}
