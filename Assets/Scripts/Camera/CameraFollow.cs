using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      
    public float smoothSpeed = 0.125f;   
    public Vector3 offset;       

    private Quaternion initialRotation;  

    void Start()
    {
        initialRotation = transform.rotation;

        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;

        desiredPosition.x = transform.position.x;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.rotation = initialRotation;
    }
}
