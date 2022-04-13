using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Camera cam;
    float camFOV;
    public float zoomSpeed;

    void Start()
    {
        camFOV = cam.fieldOfView;    
    }

  
    void Update()
    {
        float mouseScrollInput = Input.GetAxis("Mouse ScrollWheel");
        camFOV -= mouseScrollInput * zoomSpeed;
        camFOV = Mathf.Clamp(camFOV, 30, 60);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, camFOV, zoomSpeed);
    }
}
