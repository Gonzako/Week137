using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopMidpoint : MonoBehaviour
{
    private GameObject flip;
    private GameObject flop;

    void Start()
    {
        flip = GameObject.FindGameObjectWithTag("Flip");
        flop = GameObject.FindGameObjectWithTag("Flop");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = (flip.transform.position + flop.transform.position) / 2;
    }
}
