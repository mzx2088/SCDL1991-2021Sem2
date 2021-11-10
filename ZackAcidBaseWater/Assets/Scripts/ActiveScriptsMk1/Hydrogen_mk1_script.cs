using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen_mk1_script : MonoBehaviour
{
    public Transform protonMk1; //The proton instantiated in this script


    // The components we will need to enable and disable -- ALSO, the script/GameObject never deactivates!
    public SphereCollider sCdr;
    public MeshRenderer mRdr;
    public LineRenderer lRdr;
    public Rigidbody rb; // public so I can check... I don't think it's working

    public GameObject myOrbital;

    public float threshold = 0.3f; //This will be attached to a formula later!
    //public Vector3 currentVelocity;

    void Start()
    {
        // Assign components!
        sCdr = GetComponent<SphereCollider>();
        mRdr = GetComponent<MeshRenderer>();
        lRdr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();

        myOrbital = transform.Find("sp3mk1").gameObject;
        //Debug.Log("H: Am I enabled? " + sCdr.enabled);
    }

    /*
    void FixedUpdate()
    {
        Debug.Log(rb.velocity);
    }
    */
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("H: I hit something!");
        if (sCdr.enabled && other.CompareTag("Hungry"))
        {
            Vector3 otherVel = other.GetComponent<Orbital_mk1_script>().linearVel;
            float relSpeed = (otherVel - rb.velocity).magnitude;

            Debug.Log("H: Encountered a hungry orbital at "+relSpeed+"...");

            if (CompareTag("Frugal"))
            {
                //The site is active, but it's not ready to give it up.
                Debug.Log("... but I'm hanging on to it!");
            }
            else if (relSpeed >= threshold)
            {
                Debug.Log("H: Met the threshold of "+threshold+" , release the proton!");
                Transform newParentTrans = other.transform.parent;

                //Instantiate the mobile proton
                Transform clone;
                clone = Instantiate(protonMk1, transform.position, transform.rotation, newParentTrans);

                other.gameObject.tag = "Sated";
                // Make sure the orbital doesn't get any crazy ideas

                // gameObject.SetActive(false); //For testing purposes: sCdr, mRdr, lRdr, myOrbital
                /*
                sCdr.enabled = false;
                mRdr.enabled = false;
                lRdr.enabled = false;

                myOrbital.SetActive(true);
                */
                switchBondOrbital();
            }

        }
    }

    public void switchBondOrbital()
    {
        sCdr.enabled = !sCdr.enabled;
        mRdr.enabled = !mRdr.enabled;
        lRdr.enabled = !lRdr.enabled;

        myOrbital.SetActive(!myOrbital.activeSelf);
        myOrbital.tag = "Sated"; //Just in case!
    }

    /*
    private void FixedUpdate()
    {
        currentVelocity = rb.velocity;
    }
    */
}
