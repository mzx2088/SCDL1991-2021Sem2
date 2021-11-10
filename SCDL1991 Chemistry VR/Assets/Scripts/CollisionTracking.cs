using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracking : MonoBehaviour
{

    public int reaction;
    public GameObject site;

    private void Start()
    {
        reaction = 0;
        site = null;
    }

}
