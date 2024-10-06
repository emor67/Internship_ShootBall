using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    Animator animator;
    public List<GameObject> Balls = new List<GameObject>();
    public Transform handPos;
    public GameObject targetObject;

    public bool shootingIsAvailable;

    private GameObject _notListedBall;

    private void Start() {
        shootingIsAvailable = false;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        if(shootingIsAvailable == true){
            animator.SetBool("isReady", true);
        }else if(shootingIsAvailable == false){
            animator.SetBool("isReady", false);
        }
    }
    private void FixedUpdate() {
        if(shootingIsAvailable == true){
                Shoot();      
        }else if(shootingIsAvailable == false){
            
        }
        handPos = targetObject.transform;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = false;
        }
    }

    private void Shoot(){
        Balls[0].gameObject.SetActive(true);
        //Balls[0].GetComponent<Rigidbody>().velocity = Vector3.forward * 15;

        Balls[0].GetComponent<Rigidbody>().isKinematic = true;

        Balls[0].GetComponent<Rigidbody>().MovePosition(handPos.position + handPos.forward * 2);

        Balls[0].GetComponent<Rigidbody>().isKinematic = false;

        Balls[0].GetComponent<Rigidbody>().AddForce(handPos.forward * 15, ForceMode.Impulse);
        //slerp?
       
        _notListedBall = Balls[0];
        shootingIsAvailable = false;
        Balls.RemoveAt(0);
        
        Invoke("GetToThePool",1);  
        _notListedBall.SetActive(true); 
    }

    public void GetToThePool(){
        Balls.Add(_notListedBall);
        _notListedBall.transform.position = handPos.position;
        _notListedBall.SetActive(false);
    }

}
