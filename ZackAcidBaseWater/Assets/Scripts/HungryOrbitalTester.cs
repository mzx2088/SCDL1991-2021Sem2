using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryOrbitalTester : MonoBehaviour
{
    public bool measuringSpeed = false;
    public Vector3 linearVel;
    private Vector3 prevPos;
    private float speedyboy;

    private bool sated = false;
    public Material satedColour;

    
    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (measuringSpeed)
        {
            /*
            Debug.Log("Previously: " + prevPos);
            Debug.Log("Now: " + transform.position);
            // This determines the linear velocity of the orbital
            */
            linearVel = (transform.position - prevPos) / Time.deltaTime;
            prevPos = transform.position;
            speedyboy = linearVel.magnitude;
            //Debug.Log("Orbital speed: " + speedyboy);
        }
        if (tag == "Sated" && !sated)
        {
            // Only want to switch colour once at this Debug Stage, 
            GetComponent<Renderer>().material = satedColour;
            sated = true;
        }
    }
}
