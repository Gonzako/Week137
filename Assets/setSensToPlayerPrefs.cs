using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSensToPlayerPrefs : MonoBehaviour
{
    private deltaTarget target;

    private const string sens = "sens";


    void Start()
    {
        target = GetComponent<deltaTarget>();
        target.sensibility = PlayerPrefs.GetFloat(sens, 0.5f);
    }

    public void refreshValues()
    {

        target.sensibility = PlayerPrefs.GetFloat(sens, 0.5f);
    }
}
