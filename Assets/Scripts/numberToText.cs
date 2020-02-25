using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class numberToText : MonoBehaviour
{
    public void setNumberToString(float number)
    {        

        GetComponent<Text>().text = Math.Round(number, 2).ToString();
    }
}
