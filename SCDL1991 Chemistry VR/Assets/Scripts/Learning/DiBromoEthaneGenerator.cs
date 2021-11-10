using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiBromoEthaneGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 carbonScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject c1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        c1.transform.position = new Vector3(0, 0, 0.7680f);
        c1.transform.localScale = carbonScale;

        GameObject c2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        c2.transform.position = new Vector3(0, 0, -0.7680f);
        c2.transform.localScale = carbonScale;

        Vector3 hydrogenScale = new Vector3(0.16f, 0.16f, 0.16f);
        GameObject h1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h1.transform.position = new Vector3(0.5096f, 0.8826f, 1.1573f);
        h1.transform.localScale = hydrogenScale;

        GameObject h2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h2.transform.position = new Vector3(0.5096f, -0.8826f, 1.1573f);
        h2.transform.localScale = hydrogenScale;

        GameObject h3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h3.transform.position = new Vector3(-0.5096f, -0.8826f, -1.1573f);
        h3.transform.localScale = hydrogenScale;

        GameObject h4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h4.transform.position = new Vector3(-0.5096f, 0.8826f, -1.1573f);
        h4.transform.localScale = hydrogenScale;

        Vector3 bromineScale = new Vector3(0.54f, 0.54f, 0.54f);
        GameObject br1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        br1.transform.position = new Vector3(-1.0192f, 0, 1.1573f);
        br1.transform.localScale = bromineScale;

        GameObject br2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        br2.transform.position = new Vector3(1.0192f, 0, -1.1573f);
        br2.transform.localScale = bromineScale;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
