using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorSwitcher : MonoBehaviour
{
    public static Action<FlipFlopMovement[], FlipFlopMovement> onStateSwitch;
    public static Action<FlipFlopMovement[], lastButtonUsed> onWrongSwitch;

    private lastButtonUsed lastButton = lastButtonUsed.rightClick;
    private FlipFlopMovement[] flipFlops;
    private Vector2 inputVector;

    private void Start()
    {
        flipFlops = GetComponentsInChildren<FlipFlopMovement>();
    }

    private void switchStates()
    {
        foreach (FlipFlopMovement n in flipFlops)
        {
            switch (n.state)
            {
                case feetState.anchor:
                    n.makeFeet();
                    break;
                case feetState.feet:
                    onStateSwitch?.Invoke(flipFlops, n);
                    n.makeAnchor();
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (lastButton == lastButtonUsed.leftClick)
            {
                Debug.Log("badLeftClick");
                onWrongSwitch?.Invoke(flipFlops, lastButton);
            }
            inputVector.y = 1;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if(lastButton == lastButtonUsed.rightClick)
            {
                Debug.Log("badRightClick");
                onWrongSwitch?.Invoke(flipFlops, lastButton);
            }
            inputVector.x = 1;
        }
    }

    private void FixedUpdate()
    {
        switch (lastButton)
        {
            case lastButtonUsed.rightClick:
                if(inputVector.y == 1)
                {
                    switchStates();
                    lastButton = lastButtonUsed.rightClick;
                }
                break;
            case lastButtonUsed.leftClick:
                if (inputVector.x == 1)
                {
                    switchStates();
                    lastButton = lastButtonUsed.leftClick;
                }
                break;
        }
        clearInput();

    }

    private void clearInput()
    {
        inputVector = Vector2.zero;
    }

    public enum lastButtonUsed
    {
        rightClick, leftClick
    }
}