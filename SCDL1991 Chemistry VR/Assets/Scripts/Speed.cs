using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Calculates the speed of an object

public class Speed : MonoBehaviour
{
    private Vector3 oldPosition;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        oldPosition = this.transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = Vector3.Distance(oldPosition, this.transform.position);
        oldPosition = this.transform.position;
        
    }
}
