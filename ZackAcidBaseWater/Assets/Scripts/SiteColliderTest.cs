using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteColliderTest : MonoBehaviour
{
    public Transform mobileProton; //The moving proton it can instantiate

    public bool donating; //whether the site is able to yields its proton.
    // This is DIFFERENT to whether it is active (visible/rigid) or not
    public float threshold = 0.3f; //what speed is necessary for the reaction to happen?

    public Rigidbody rb; //The hydrogen's rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && other.gameObject.CompareTag("Hungry"))
        {
            Vector3 otherVel = other.GetComponent<HungryOrbitalTester>().linearVel;
            float relSpeed = (otherVel - rb.velocity).magnitude;
            //Debug.Log("An orbital hit me at " + relSpeed + "(rel)");

            if (!donating)
            {
                //If the site isn't donating [but is active, e.g. OH- won't give up its last one
                Debug.Log(relSpeed + " ? I don't care!");
            }
            else if (relSpeed >= threshold)
            {
                Debug.Log(relSpeed + " surpassed " + threshold + " by " + (relSpeed - threshold));
                Transform newParentTrans = other.transform.parent;

                //Instantiate the mobile proton
                Transform clone;
                clone = Instantiate(mobileProton, transform.position, transform.rotation, newParentTrans);
                //Debug.Log("I tried to summon it, with parent " + newParentTrans);

                //make sure the orbital is sated (and doesn't grab another one!)
                other.gameObject.tag = "Sated"; //It should turn red!

                // Deactivate itself... The Renderer + Collider, or maybe the whole component?
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log(relSpeed + " was too slow by " + (threshold - relSpeed));
            }
        }
    }

    private void OnDisable()
    {
        //Debug.Log("Ah! I am no more...");
    }
}
