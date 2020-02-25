using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Bindings;

public class lineUpdater : MonoBehaviour
{
    public Color colorAtMaxPosition;
    public Color colorAtNonMax;
    public float maxDistance = 1.3f;
    public Transform startPoint;
    public Transform endPoint;


    private LineRenderer lR;

    private void Awake()
    {
        lR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lR.SetPosition(0, startPoint.position);
        lR.SetPosition(1, endPoint.position);
        if (Vector3.Distance(startPoint.position, endPoint.position) > maxDistance)
        {

            lR.startColor = colorAtMaxPosition;
            lR.endColor = colorAtMaxPosition;
        }
        else
        {
            lR.startColor = colorAtNonMax;
            lR.endColor = colorAtNonMax;
        }
    }
}
