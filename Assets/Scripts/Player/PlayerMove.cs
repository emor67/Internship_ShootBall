using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;       
    public float horizontalSpeed = 3f; 
    public float smoothTime = 0.1f;    

    private Rigidbody _rb;
    private float _targetHorizontal = 0f;
    private float _currentHorizontal = 0f;
    private float _horizontalVelocity = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;  
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * moveSpeed;

        float horizontalInput = Input.GetAxis("Horizontal");

        _targetHorizontal = horizontalInput * horizontalSpeed;
        _currentHorizontal = Mathf.SmoothDamp(_currentHorizontal, _targetHorizontal, ref _horizontalVelocity, smoothTime);
        Vector3 horizontalMove = transform.right * _currentHorizontal;

        _rb.velocity = forwardMove + horizontalMove;
    }
}
