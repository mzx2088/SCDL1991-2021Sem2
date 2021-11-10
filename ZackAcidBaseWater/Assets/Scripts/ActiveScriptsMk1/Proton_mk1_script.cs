using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proton_mk1_script : MonoBehaviour
{
    public Transform myParent; //Just to check!
    public float protonSpeed = 1.2f;
    private Hydrogen_mk1_script destinationScript;
    
    // Start is called before the first frame update
    void Start()
    {
        myParent = transform.parent;
        destinationScript = GetComponentInParent<Hydrogen_mk1_script>();
        //Should be set by the Instantiate function!
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, myParent.position, protonSpeed * Time.deltaTime);
        float separation = (transform.position - myParent.position).magnitude;
        if (separation < 0.1f)
        {
            Transform siblingOrbital = myParent.Find("sp3mk1");
            //Find it's relevant orbital, and make sure it found it!
            if (siblingOrbital != null)
            {
                if (siblingOrbital.CompareTag("Sated"))
                {
                    //The summoner should have made it so already!
                    Debug.Log("P: I will now deactivate the orbital!");
                    destinationScript.switchBondOrbital();
                }
            }


            //Destroy itself upon reaching destination
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("P: Goodbye!");
    }
}
