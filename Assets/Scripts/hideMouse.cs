﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideMouse : MonoBehaviour
{
    public void lockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
