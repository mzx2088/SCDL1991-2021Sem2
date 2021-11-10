using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProtonMover : MonoBehaviour
{
    public Transform myDaddy;
    public float speed = 1.2f;
    //Visible just to check it's working correctly
    
    // Start is called before the first frame update, when it is enabled!
    void Start()
    {
        myDaddy = transform.parent;
        // Which SHOULD be set by the Instantiate command
        //Debug.Log("I'm a proton and " + myDaddy + "is my Daddy!");
    }

    /*
     * All this has to do is move towards it parent, and when it gets there
     *      Activate "SOMETHING" on the parent site, that changes what's visible.
     *      Destroy Itself.
     * What it does not handle is:
     *      Setting it's parent (the Instantiate command does that)
     *      Making the target orbital not "Hungry" (the OnTriggerEnter does that)
     *      Colliding with anything (I might remove the collider!)
     */

    // Update is called once per frame, no need for Fixed Update. No Physics!
    void Update()
    {
        // myDaddy is a reference value... it should keep track of its position.
        transform.position = Vector3.MoveTowards(transform.position, myDaddy.position, speed * Time.deltaTime);

        float separation = (transform.position - myDaddy.position).magnitude;
        if (separation < 0.1f)
        {
            Transform siblingOrbital = myDaddy.Find("SP3Orbital");
            if(siblingOrbital != null)
            {
                //Debug.Log("I touched an orbital" + siblingOrbital + "...");
                if (siblingOrbital.gameObject.CompareTag("Sated"))
                {
                    //I need an indication on the orbital that the exchange was completed                    
                    siblingOrbital.localScale = Vector3.Scale(siblingOrbital.localScale, new Vector3(0.1f, 0.1f, 1f));
                    //Debug.Log("... and completed the orbital sating!");

                    //In practice, this would deactivate the orbital, and reactivate the site.
                }
            }

            Destroy(gameObject);
        }
    }

    /*
    private void OnDestroy()
    {
        Debug.Log("Goodbye, cruel world!");
    }
    */
}
