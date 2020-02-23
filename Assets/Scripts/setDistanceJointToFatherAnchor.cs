using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDistanceJointToFatherAnchor : MonoBehaviour
{
    private DistanceJoint2D googlyAnchor;
    void Start()
    {

        googlyAnchor = GetComponent<DistanceJoint2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        googlyAnchor.connectedAnchor = transform.parent.position;
    }
}
