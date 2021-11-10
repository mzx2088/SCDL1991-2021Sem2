using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital_mk1_script : MonoBehaviour
{
    //Responsible for measuring own velocity
    private Rigidbody parentVelocityAtom; 
    public Vector3 linearVel;

    //Changed by a formula called by the central atom, accessed by the atom it collides with.
    public float nucleophilicity = 0.3f; //Set in inspector!

    // The mesh renderer and the two materials it will use.
    public MeshRenderer meshRenderer;
    public Material satedMaterial;
    public Material hungryMaterial;
    public bool satedColour; // just to keep track




    /*              EXECUTION ORDER NOTES
     * AWAKE comes first and happens ONCE, but other things may not be loaded yet. Fine for setting up object itself.
     * START also happens ONCE, but other things will have been loaded.
     * OnEnable happens EVERYTIME it is enabled... but the central atom handles this case. Needs to update ALL orbitals
     */
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        parentVelocityAtom = GetComponentInParent<Rigidbody>();

        OrbitalRefresh(nucleophilicity);

    }
    

    // Update called to ACTIVE OBJECTS. Once per frame. Before FixedUpdate + OnDestroy.
    void FixedUpdate()
    {
        linearVel = parentVelocityAtom.velocity;
    }

    /*
     * Whenever a reaction happens (an atom becomes bond and vice versa), a signal sent to central atom
     * Central atom counts up hydrogens, delivers new electrophilicity (generosity) and nucleophilicity (hunger) values to the right places.
     * The hunger value is sent here, in order to:
     * * a) Update the nucleophilicity value
     * * b) Set the GameObject's tag correctly [may be unnecessary in long run]
     * * c) Check if we need to change colour! (Material)
     * * d) Change colour if we do
     */
    public void OrbitalRefresh(float hunger)
    {
        nucleophilicity = hunger;
        if (nucleophilicity <=0)
        {
            tag = "Sated";
            meshRenderer.material = satedMaterial;
            satedColour = true;
        }
        else
        {
            tag = "Hungry";
            meshRenderer.material = hungryMaterial;
            satedColour = false;
        }
    }

    
}
