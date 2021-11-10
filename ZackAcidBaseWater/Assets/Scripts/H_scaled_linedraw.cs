using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_scaled_linedraw : MonoBehaviour
{
    private LineRenderer lineRenderer; //refers to the component
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
        lineRenderer.SetPosition(1, transform.localPosition * -1);
        //has to go the other direction!

        DrawBondLine(0.1f, 0.08f);

    }

    // Start is called once! Only on the first time it shows up! Luckily, the sites never move within own coordinate system.
    void DrawBondLine(float startWidth, float endWidth)
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.useWorldSpace = false;
    }
}
