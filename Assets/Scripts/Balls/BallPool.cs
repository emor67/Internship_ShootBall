using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    Animator animator;
    public List<GameObject> Balls = new List<GameObject>();
    public Transform handPos;
    public GameObject targetObject;

    public bool shootingIsAvailable;
    private bool hasShot = false;  

    private GameObject _notListedBall;

    private void Start() {
        shootingIsAvailable = false;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        if(shootingIsAvailable == true){
            animator.SetBool("isReady", true);
        } else if(shootingIsAvailable == false){
            animator.SetBool("isReady", false);
        }

        handPos = targetObject.transform;  
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = true;
            hasShot = false;  
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Hoop") && !hasShot && shootingIsAvailable){
            Shoot();
            hasShot = true; 
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = false;
            animator.SetBool("isReady", false);
            //Debug.Log("anim stop");
        }
    }

    private void Shoot(){
        Balls[0].gameObject.SetActive(true);

        Balls[0].GetComponent<Rigidbody>().isKinematic = true;
        Balls[0].GetComponent<Rigidbody>().MovePosition(handPos.position + handPos.forward * 2);
        Balls[0].GetComponent<Rigidbody>().isKinematic = false;
        Balls[0].GetComponent<Rigidbody>().AddForce(handPos.forward * 15, ForceMode.Impulse);
        //slerp

        _notListedBall = Balls[0];
        Balls.RemoveAt(0);

        Invoke("GetToThePool", 0.7f);  
    }

    private void GetToThePool(){
        Balls.Add(_notListedBall);
        _notListedBall.transform.position = handPos.position;
        _notListedBall.SetActive(false);
        shootingIsAvailable = true;
        hasShot = false;  
    }
}
