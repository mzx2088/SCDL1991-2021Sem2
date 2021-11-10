using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellerScript : MonoBehaviour
{
    public float speed = 1.2f;
    public Transform parentTransform;
    private Vector3 target;
    
    void Start()
    {
        //Let's just attach it to cuber to start
        Transform grandparent = transform.parent;
        parentTransform = grandparent.Find("leftsphere/Spherel");
        //Debug.Log("Trying to set " + parentTransform.name + " as the parent...");


        //In actuality, would be setting the parent of a separate GameObject
        transform.SetParent(parentTransform);
        //Debug.Log("The parent was set to " + transform.parent.name);
    }

    void Update()
    {
        target = parentTransform.position;
        //we make it move towards the target (the transform of the parent)
        /*For a slow down as it nears the target
        float targetDistance = Vector3.Distance(transform.position, target);
        float moveStep = speed * Time.deltaTime * Mathf.Exp(targetDistance);
        transform.position = Vector3.MoveTowards(transform.position, target, moveStep);
        */
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    //Upon collision with a trigger, this object sets its parent to the triggers parent 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("egMoveToward"))
        {
            Transform newParentTransform = other.transform.parent;
            //Debug.Log("We collided with" + other.name);
            transform.SetParent(newParentTransform);
            parentTransform = transform.parent;
            //Debug.Log("The new parent is" + parentTransform);
            
            
            //Debug.Log("Collided with " + other.name + "; new parent is " + parentTransform);

        }
    }
    /*
    It works! When the Traveller collider (no Rigidbody) interacts with a tagged [egMoveToward]
        trigger, it successfully converts its own parentage
    So, we can use a trigger to set the path of a moving GameObject+Collider, by
        making it move toward its new parent's position using Vector3.MoveTowards(a,b,step);
    For future, could consider an acceleration/deceleratio curve instead?
        Perhaps speed = 'the slowest speed'; step = Time.deltaTime * speed * exp(distance?)
        Meaning that v. close to target, step = T.dT * speed, but far away it's more?
     */
    }
