using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberToText : MonoBehaviour
{
    public void setNumberToString(float number)
    {        
        GetComponent<Text>().text = number.ToString();
    }
}
