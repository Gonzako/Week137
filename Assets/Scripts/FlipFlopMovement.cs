using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopMovement : MonoBehaviour
{
    public float massAsAnchor;
    public float massAsFeet;

    private Rigidbody2D rb;
    private TargetJoint2D mouseJoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mouseJoint = GetComponent<TargetJoint2D>();
    }

    public void makeAnchor()
    {
        rb.mass = massAsAnchor;
        mouseJoint.enabled = false;
    }

    public void makeFeet()
    {
        rb.mass = massAsFeet;
        mouseJoint.enabled = true;
    }
}
