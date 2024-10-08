using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    public GameObject uiElementTutorial;
    public float moveSpeed = 5f;       
    public float horizontalSpeed = 5f; 
    public float smoothTime = 0.1f;  
    public bool canMove;

    private Rigidbody _rb;
    private float _targetHorizontal = 0f;
    private float _currentHorizontal = 0f;
    private float _horizontalVelocity = 0f;

    void Start()
    {
        canMove = false;
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;  
        animator = gameObject.GetComponent<Animator>();
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

    private void Update() {
        if(canMove == false){
            moveSpeed = 0f;
            horizontalSpeed = 0f;
            animator.SetBool("canMove", false);
        }else if(canMove == true){
            moveSpeed = 5f;
            horizontalSpeed = 5f;
            animator.SetBool("canMove", true);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            canMove = true;
            uiElementTutorial.SetActive(false);
        }
    }
}
