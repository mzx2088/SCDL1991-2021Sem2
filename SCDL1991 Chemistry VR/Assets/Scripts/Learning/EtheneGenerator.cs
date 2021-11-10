using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtheneGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 carbonScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject c1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        c1.transform.position = new Vector3(0, 0, 0.6695f);
        c1.transform.localScale = carbonScale;

        GameObject c2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        c2.transform.position = new Vector3(0, 0, -0.6695f);
        c2.transform.localScale = carbonScale;

        Vector3 hydrogenScale = new Vector3(0.16f, 0.16f, 0.16f);
        GameObject h1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h1.transform.position = new Vector3(0, 0.9289f, 1.2321f);
        h1.transform.localScale = hydrogenScale;

        GameObject h2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h2.transform.position = new Vector3(0, -0.9289f, 1.2321f);
        h2.transform.localScale = hydrogenScale;

        GameObject h3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h3.transform.position = new Vector3(0, 0.9289f, -1.2321f);
        h3.transform.localScale = hydrogenScale;

        GameObject h4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        h4.transform.position = new Vector3(0, -0.9289f, -1.2321f);
        h4.transform.localScale = hydrogenScale;


    }

    // Update is called once per frame
    void Update()
    {

    }
}