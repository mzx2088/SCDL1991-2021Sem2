using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraMover : MonoBehaviour
{
    public float cameraMoveV = 5f;
    public float cameraRotV = 40f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * cameraMoveV * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * cameraMoveV * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -cameraRotV * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, cameraRotV * Time.deltaTime);
    }
}
