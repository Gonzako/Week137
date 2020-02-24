using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraReferencer : MonoBehaviour
{
    public string cameraTag = "MainCamera";

    private void Awake()
    {
        var canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
    }
}
