using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   public float moveSpeed = 5f;       
    public float horizontalSpeed = 3f; 
    public float smoothTime = 0.1f;    

    private Rigidbody rb;
    private float targetHorizontal = 0f;
    private float currentHorizontal = 0f;
    private float horizontalVelocity = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;  
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * moveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");

        targetHorizontal = horizontalInput * horizontalSpeed;
        currentHorizontal = Mathf.SmoothDamp(currentHorizontal, targetHorizontal, ref horizontalVelocity, smoothTime);
        Vector3 horizontalMove = transform.right * currentHorizontal;

        rb.velocity = forwardMove + horizontalMove;
    }
}
