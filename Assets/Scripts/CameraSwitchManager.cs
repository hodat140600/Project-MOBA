using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchManager : MonoBehaviour
{
    CameraFollowing cameraFollowingScript;
    CameraRoam cameraRoamScript;
    bool camViewChanged = false;

    void Start()
    {
        cameraFollowingScript = GetComponent<CameraFollowing>();
        cameraRoamScript = GetComponent<CameraRoam>();
        cameraRoamScript.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(camViewChanged);
        if (!camViewChanged) {
            if (Input.GetKeyDown(KeyCode.Y)) {
                camViewChanged = true;
                cameraRoamScript.enabled = true;
                cameraFollowingScript.enabled = false;
            }
        }else if (camViewChanged)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                camViewChanged = false;
                cameraRoamScript.enabled = false;
                cameraFollowingScript.enabled = true;
            }
        }
    }
}
