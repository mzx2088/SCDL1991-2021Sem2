using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeftPlease : MonoBehaviour
{
    public float slideSpeed = 0.5f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * slideSpeed * Time.deltaTime);
    }
}
