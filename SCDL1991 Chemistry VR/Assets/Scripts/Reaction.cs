using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Universal code for reactions of the form: HC + XY -> HCX + Y -> HCXY

public class Reaction : MonoBehaviour
{
    private GameObject molecule;
    private GameObject collide1;
    private GameObject intermediate;
    private GameObject collide2;
    private GameObject product;
    private int stage;

    public GameObject moleculePrefab;
    public GameObject collide1Prefab;
    public GameObject intermediatePrefab;
    public GameObject collide2Prefab;
    public GameObject productPrefab;
    public Vector3 location1;
    public Vector3 location2;
    public double ActivationEnergy1;
    public double ActivationEnergy2;

    CollisionTracking collisionScript;
    Speed speedScript;


    // Start is called before the first frame update
    void Start()
    {
        
        stage = 0;
        
        //Creates initial molecule based on prefab
        molecule = Instantiate(moleculePrefab, location1, Quaternion.identity);
        molecule.transform.parent = this.transform;

        //Creates initial molecule to collide with the other based on prefab
        collide1 = Instantiate(collide1Prefab, location2, Quaternion.identity);
        collide1.transform.parent = this.transform;

        //Loads collision detection and speed from hydrocarbon and molecule
        collisionScript = molecule.GetComponent<CollisionTracking>();
        speedScript = collide1.GetComponent<Speed>();

    }


    // Update is called once per frame 
    void Update()
    {
                               
        if(collisionScript.reaction == 1 && stage == 0 && speedScript.speed > ActivationEnergy1)
        {
            //change reaction stage
            stage = 1;

            //get location and rotation of reacting molecules and replace them with new molecules
            intermediate = Instantiate(intermediatePrefab, molecule.transform.position, molecule.transform.rotation);
            intermediate.transform.parent = this.transform;

            collide2 = Instantiate(collide2Prefab, collide1.transform.position, collide1.transform.rotation);
            collide2.transform.parent = this.transform;

            //destroy reacting molecules 
            Destroy(molecule);
            Destroy(collide1);

            //update collision and speed detection to follow new molecules
            collisionScript = intermediate.GetComponent<CollisionTracking>();
            speedScript = collide2.GetComponent<Speed>();

        }


        if (collisionScript.reaction == 2 && stage == 1 && speedScript.speed > ActivationEnergy2)
        {
            //change reaction stage
            stage = 2;

            //get location and rotation of reacting molecules and replace them with new molecules
            product = Instantiate(productPrefab, intermediate.transform.position, intermediate.transform.rotation);
            product.transform.parent = this.transform;

            //destroy reacting molecules 
            Destroy(intermediate);
            Destroy(collide2);

            //update collision and speed detection to follow product
            collisionScript = product.GetComponent<CollisionTracking>();
            speedScript = product.GetComponent<Speed>();
        }

    }

}
