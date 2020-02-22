using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set the TargetJoint2D to follow the mouse position.
/// </summary>
public class MouseTarget : MonoBehaviour
{
    Camera mainCam;
	TargetJoint2D targetJoint;

	void Start()
	{
		// Fetch the target joint.
		targetJoint = GetComponent<TargetJoint2D> ();
        mainCam = Camera.main;
		// Finish if no joint detected.
		if (targetJoint == null)
			return;
	} 

	void FixedUpdate ()
	{
        
		// Finish if no joint detected.
		if (targetJoint == null)
			return;

		// Calculate the world position for the mouse.
		var worldPos = mainCam.ScreenToWorldPoint (Input.mousePosition);

		// Set the joint target.
		targetJoint.target = worldPos;
	}
}
