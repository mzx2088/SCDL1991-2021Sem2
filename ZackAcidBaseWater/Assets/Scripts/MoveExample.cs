using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveExample : MonoBehaviour
{
    public float speed = 1.0f;

    private string targetName;
    public string newTargetName;
    public Transform target;
    public Transform newTarget;
    private Transform parent; //to access the sibling, would be the sp3 site
    void Start()
    {
        // Gotta access the sibling
        Transform parent = transform.parent;
        targetName = "MoveTarget1";
        target = parent.Find(targetName);
        newTargetName = targetName;
        newTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target
        float step = speed * Time.deltaTime; //distance to move or stop in
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        /* I have no clue what
        //a simple conditional to switch target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            
            //look to the other target
            if (targetName == "MoveTarget1")
            {
                newTargetName = "MoveTarget2";
            }
            else if (targetName == "MoveTarget2")
            {
                newTargetName = "MoveTarget1";
                //In the actual thing, from (on) trigger, trigger.parent -> the transform
            }
            //switch to other target
            newTarget = parent.Find(newTargetName);
            target = newTarget;
        }
        */

    }
}
