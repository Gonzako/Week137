using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorSwitcher : MonoBehaviour
{
    public static Action<FlipFlopMovement[], FlipFlopMovement> onStateSwitch;
    public static Action<FlipFlopMovement[], buttonToChange> onWrongSwitch;

    private buttonToChange changeButton = buttonToChange.rightClick;
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
            if (changeButton == buttonToChange.leftClick)
            {
                Debug.Log("badLeftClick");
                onWrongSwitch?.Invoke(flipFlops, changeButton);
            }
            inputVector.x = 1;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if(changeButton == buttonToChange.rightClick)
            {
                Debug.Log("badRightClick");
                onWrongSwitch?.Invoke(flipFlops, changeButton);
            }
            inputVector.y = 1;
        }
    }

    private void FixedUpdate()
    {
        switch (changeButton)
        {
            case buttonToChange.rightClick:
                if(inputVector.y == 1)
                {
                    switchStates();
                    changeButton = buttonToChange.leftClick;
                }
                break;
            case buttonToChange.leftClick:
                if (inputVector.x == 1)
                {
                    switchStates();
                    changeButton = buttonToChange.rightClick;
                }
                break;
        }
        clearInput();

    }

    private void clearInput()
    {
        inputVector = Vector2.zero;
    }

    public enum buttonToChange
    {
        rightClick, leftClick
    }
}