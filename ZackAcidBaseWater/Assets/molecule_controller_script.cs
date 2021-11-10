using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molecule_controller_script : MonoBehaviour
{
    // Holds the scripts of the attached hydrogen sites (each w/ atom + orbital)
    private H_mk2_script[] boundHydrogens;
    private Orbital_mk1_script[] boundOrbitals;


    public int numberOfH;
    // threshold is determined by bondResistance - (nucleophilicity/hunger of what it collides with)
    // i.e. bondResistance is pretty high, but lowered by opposing hunger
    // NOTE WELL!!! bondResistance = 0 actually means INFINITE
    private float bondResistance;
    private float hunger;

    /*
     * These arrays hold the nucleophilicity/hunger of the orbitals
     * and the electrophilicy/generosity of the hydrogen atoms.
     * Conveniently, index corresponds to no. of H attached to central atom.
     * These are public to allow editing in the inspector for different atoms.
     * Below is H2O, notice how only [1],[2],[3] have values that could cause change.
     */
    public float[] resistanceArray = new float[5] { 0f, 0f, 0.5f, 0.7f, 0f};
    public float[] nucArray = new float[5] { 0f, 0.7f, 0.5f, 0f, 0f };

    void Awake()
    {
        boundHydrogens = GetComponentsInChildren<H_mk2_script>(); // don't need true, as this script is ALWAYS ACTIVE
        boundOrbitals = GetComponentsInChildren<Orbital_mk1_script>(true);
        //Debug.Log("There are " + boundOrbitals.Length+" orbitals on me!"); //Just to check, it should always be 4! Even if only two shown
        numberOfH = 0;
        foreach (H_mk2_script hydrogen in boundHydrogens)
        {
            if(hydrogen.amIBound)
            {
                numberOfH++;
            }
        }
    }

    /*
     * Used when an orbital/hydrogen transition occurs. Counts new number of bonds.
     * Returns the integer, but also 'STUNS' the atoms, preventing any H-donation.
     * This is to prevent reactions immediately reversing when a new hungry orbital appears
     * where a hydrogen has just left.
     */
    private int CountAndStun()
    {
        int count = 0;
        foreach (H_mk2_script hydrogen in boundHydrogens)
        {
            if (hydrogen.amIBound)
            {
                count = count + 1;
            }
            hydrogen.stunned = true;
        }
        // An invoked function later unstuns all of them
        //Debug.Log("I counted " + count + " hydrogens!");
        return count;
    }

    /*
     * This function is CALLED ON by a hydrogen when it undergoes SwitchBondOrbital
     * in order to update it's nucleo/electrophilicity values, so it can "keep track"
     * of what molecule it is to make sure it acts accordingly.
     * It updates the hydrogen atom's electrophilicity/generosity directly, 
     * but passes the orbital's value indirectly by calling a function.
     * This is because I need to call a function further down the hierarchy anyway.
     */
    public void MoleculeUpdate()
    {
        numberOfH = CountAndStun();
        bondResistance = resistanceArray[numberOfH];
        hunger = nucArray[numberOfH];
        foreach (H_mk2_script hydrogenScript in boundHydrogens)
        {
            hydrogenScript.bondBarrier = bondResistance;
        }

        foreach (Orbital_mk1_script orbitalScript in boundOrbitals)
        {
            orbitalScript.OrbitalRefresh(hunger);
        }
        Invoke("UnStun",1f);

    }

    // INVOKED after a duration, following MoleculeUpdate
    private void UnStun()
    {
        foreach (H_mk2_script hydrogen in boundHydrogens)
        {
            hydrogen.stunned = false;
        }
        //Debug.Log("The atoms are free once more.");
    }
}
