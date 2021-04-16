using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMethods : MonoBehaviour
{

    public int zoomSize = 70;
    public int zoomLimit = 4;

    void Start()
    {
        GetComponent<Camera>().fieldOfView = zoomSize;
    }

    void Update()
    {

    if (Input.GetAxis("Mouse ScrollWheel") < 0) 
    {
        if (zoomLimit != 0)
        {
            zoomSize += 5;
            zoomLimit--;
        }
    }

    if (Input.GetAxis("Mouse ScrollWheel") > 0)
    {
        if (zoomLimit < 6)
        {
            zoomSize -= 5;
            zoomLimit++;
        }
    }

    GetComponent<Camera>().fieldOfView = zoomSize;

    }
}
