using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOffset;
    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;
    
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    
    void Update()
    {
        Vector3 newPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}
