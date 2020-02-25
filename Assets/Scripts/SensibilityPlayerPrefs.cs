using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensibilityPlayerPrefs : MonoBehaviour
{

    private const string  sensibilityName = "sens";

    public void setPlayerPrefSensibility(float value)
    {
        PlayerPrefs.SetFloat(sensibilityName, value);
    }


    private void OnEnable()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(sensibilityName, 0.5f);
    }

    public float getPlayerSens()
    {
        return PlayerPrefs.GetFloat(sensibilityName, 0.5f);
    }

}
