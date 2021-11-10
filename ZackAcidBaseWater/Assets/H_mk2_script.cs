using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_mk2_script : MonoBehaviour
{
    public bool amIBound;
    public bool stunned = false;
    public float bondBarrier = 0.5f; 
    // The barrier to reaction, reduced by the hunger/nucleophilicity of the orbital it collides with.
    // Should be high, but NOTE WELL!!!!!!!!!!!!!!!! bondBarrier = 0, means INFINITE! [due to how the if-else's work]
    
    public Transform protonMk2; //The proton instantiated in this script
    public molecule_controller_script centralScript;

    // The components we will need to enable and disable -- ALSO, the script/GameObject never deactivates!
    public SphereCollider sCdr;
    private MeshRenderer mRdr;
    private LineRenderer lRdr;
    public Rigidbody rb; // public so I can check... I don't think it's working

    private GameObject myOrbital;

    private float threshold = 4.0f; //This will be attached to a formula later!
    //public Vector3 currentVelocity;

    void Awake()
    {
        centralScript = GetComponentInParent<molecule_controller_script>();
        // Assign components!
        sCdr = GetComponent<SphereCollider>();
        mRdr = GetComponent<MeshRenderer>();
        lRdr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();

        myOrbital = transform.Find("sp3mk2").gameObject;
        //Debug.Log("H: Am I enabled? " + sCdr.enabled);
    }

    private void Start()
    {
        centralScript.MoleculeUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Is the atom there? Is it too soon after another reaction? Did i hit an ORBITAL?
        if (sCdr.enabled && !stunned && other.CompareTag("Hungry"))
        {
            //Debug.Log("H hit an orbital");
            /*
             * I nest the if statement here because, in future, perhaps player feedback system
             * e.g. "That hydrogen can't donate!" or it could flash a certain colour.
             * Would need an else if/else on this step...
             * Similarly, you could move other.CompareTag("Hungry") inside or rather, make all Orbitals have the "orbital" tag
             * and use GetComponent Immediately?
             */
            // Does this hydrogen WANT to react?
            if (bondBarrier >0)
            {
                Orbital_mk1_script orbitalStruck = other.GetComponent<Orbital_mk1_script>();
                Vector3 otherVel = orbitalStruck.linearVel;
                float relSpeed = (otherVel - rb.velocity).magnitude;

                float otherNuc = orbitalStruck.nucleophilicity;
                threshold = bondBarrier - otherNuc;

                Debug.Log("Reacted at "+relSpeed+" speed, with a threshold of "+threshold+".");

                if (relSpeed>=threshold)
                {
                    Transform newParentTrans = other.transform.parent;

                    Transform clone;
                    clone = Instantiate(protonMk2, transform.position, transform.rotation, newParentTrans);

                    other.gameObject.tag = "Sated"; //Don't react during the transition please!
                    //Debug.Log("Hydrogen detached successfully.");
                    SwitchBondOrbital();
                }
                else
                {
                    Debug.Log("The collision was too weak.");
                }
            }
            else
            {
                Debug.Log("but H did not want to give.");
            }
            
        }
    }

    /* Just in case! Here's the old one.
    private void OnTriggerEnter(Collider other)
    {
        if (sCdr.enabled && other.CompareTag("Hungry"))
        {
            Vector3 otherVel = other.GetComponent<Orbital_mk1_script>().linearVel;
            float relSpeed = (otherVel - rb.velocity).magnitude;

            Debug.Log("H: Encountered a hungry orbital at " + relSpeed + "...");

            if (CompareTag("Frugal"))
            {
                //The site is active, but it's not ready to give it up.
                Debug.Log("... but I'm hanging on to it!");
            }
            else if (relSpeed >= threshold)
            {
                Debug.Log("H: Met the threshold of " + threshold + " , release the proton!");
                Transform newParentTrans = other.transform.parent;

                //Instantiate the mobile proton
                Transform clone;
                clone = Instantiate(protonMk2, transform.position, transform.rotation, newParentTrans);

                other.gameObject.tag = "Sated";
                // Make sure the orbital doesn't get any crazy ideas

                SwitchBondOrbital();
            }
        }
    }
     */


    public void SwitchBondOrbital()
    {
        sCdr.enabled = !sCdr.enabled;
        mRdr.enabled = !mRdr.enabled;
        lRdr.enabled = !lRdr.enabled;
        amIBound = !amIBound;

        myOrbital.SetActive(!myOrbital.activeSelf);
        myOrbital.tag = "Sated"; //Just in case!

        centralScript.MoleculeUpdate();
    }

}
