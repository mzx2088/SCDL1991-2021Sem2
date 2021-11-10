using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BromineGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bromineScale = new Vector3(0.54f, 0.54f, 0.54f);
        GameObject br1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        br1.transform.position = new Vector3(0, 0, 1.1405f);
        br1.transform.localScale = bromineScale;

        GameObject br2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        br2.transform.position = new Vector3(0, 0, -1.1405f);
        br2.transform.localScale = bromineScale;



    }

    // Update is called once per frame
    void Update()
    {

    }
}