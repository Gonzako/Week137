﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaTarget : MonoBehaviour
{
    [SerializeField] public float sensibility = 5f;

    private TargetJoint2D mouseJoint;
    private Vector2 mouseDelta;

    // Start is called before the first frame update
    void Awake()
    {
        mouseJoint = GetComponent<TargetJoint2D>();
    }

    private void OnEnable()
    {
        mouseJoint.target = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        mouseDelta.x += Input.GetAxis("Mouse X");
        mouseDelta.y += Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        mouseJoint.target += mouseDelta * sensibility;
        mouseDelta = Vector2.zero;
    }


}
