using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Scaled_Tetrahedron : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject h1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h1.transform.position = new Vector3(1.8f, 1.8f, 1.8f);
        //The hydrogens are of scale 1 (for bond reasons).
        //The empty object will scale it to be reasonable.
        GameObject h2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h2.transform.position = new Vector3(-1.8f, 1.8f, -1.8f);
        GameObject h3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h3.transform.position = new Vector3(1.8f, -1.8f, -1.8f);
        GameObject h4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h4.transform.position = new Vector3(-1.8f, -1.8f, 1.8f);

        GameObject c1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        c1.transform.position = new Vector3(0, 0, 0);
        c1.transform.localScale = new Vector3(1.27f, 1.27f, 1.27f);
        //This line changes the size of the centre atom
    }

    void Update()
    {
        
    }
}
