using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorController : MonoBehaviour
{
    [Header("Bones")]
    public Transform startBone;
    public Transform endBone;

    [Header("Targets")]
    public Transform startTarget;
    public Transform endTarget;

    private void Update()
    {
        if (startTarget != null)
            startBone.position = startTarget.position;

        if (endTarget != null)
            endBone.position = endTarget.position;

        if (startTarget != null && endTarget != null)
        {
            Vector3 direction = (endTarget.position - startTarget.position).normalized;
            startBone.rotation = Quaternion.LookRotation(direction);
            endBone.rotation = Quaternion.LookRotation(direction);
        }
    }
}
