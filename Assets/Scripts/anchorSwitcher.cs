using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class anchorSwitcher : MonoBehaviour
{

    /// <summary>
    /// True is leftClick false is rightClick
    /// </summary>
    [Tooltip("True is leftClick false is rightClick")]
    public BoolGameEvent onStateChange;

    /// <summary>
    /// True is leftClick false is rightClick the button sent is the 
    /// </summary>
    [Tooltip("True is leftClick false is rightClick the button sent is the next button to change")]
    public BoolGameEvent onWrongChange;
    public static event Action<FlipFlopMovement[], FlipFlopMovement> onStateSwitch;
    public static event Action<FlipFlopMovement[], buttonToChange> onWrongSwitch;

    private buttonToChange changeButton = buttonToChange.rightClick;
    private FlipFlopMovement[] flipFlops;
    private Vector2 inputVector;

    private void Start()
    {
        flipFlops = GetComponentsInChildren<FlipFlopMovement>();
    }

    private void switchStates()
    {
        onStateChange.Raise(changeButton == buttonToChange.leftClick);
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
                onWrongChange.Raise(true);
                onWrongSwitch?.Invoke(flipFlops, changeButton);
            }
            inputVector.x = 1;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if(changeButton == buttonToChange.rightClick)
            {
                onWrongChange.Raise(false);
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
                    changeButton = buttonToChange.leftClick;
                    switchStates();
                }
                break;
            case buttonToChange.leftClick:
                if (inputVector.x == 1)
                {
                    changeButton = buttonToChange.rightClick;
                    switchStates();
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