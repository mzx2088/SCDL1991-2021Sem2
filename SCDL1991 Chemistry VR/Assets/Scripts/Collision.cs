
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//determines which molecule collided with the trigger area

public class Collision : MonoBehaviour
{
    

    CollisionTracking collisionTracker;


    private void Start()
    {
        collisionTracker = this.transform.parent.transform.parent.GetComponent<CollisionTracking>();
    }

    //list of potential atoms to collide this list can be expanded
    void OnTriggerEnter(Collider other)
    {

        collisionTracker.site = this.transform.parent.gameObject;

        if (other.gameObject.tag == "Hydrogen")
        {
            
            collisionTracker.reaction = 1;
            
        }

        if (other.gameObject.tag == "Bromine")
        {
            collisionTracker.reaction = 2;

        }

    }

    //Removes potential to react when atom exits the trigger area
    void OnTriggerExit(Collider other)
    {
        collisionTracker.reaction = 0;
        collisionTracker.site = null;
    }


}