using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallControll : MonoBehaviour
{
    Animator animator;
    public List<GameObject> Balls = new List<GameObject>();
    public Transform handPos;
    public Transform targetHoopPos;
    public GameObject targetHoop;
    private GameObject ball;
    public GameObject targetObject;

    public bool shootingIsAvailable;

    private GameObject _notListedBall;

    private float _t = 0;

    private void Start() {
        shootingIsAvailable = false;
        animator = gameObject.GetComponent<Animator>();
        
    }


    private void Update() {
        if(shootingIsAvailable == true){
            animator.SetBool("isReady", true);
            //Shoot();      
        }else if(shootingIsAvailable == false){
            animator.SetBool("isReady", false);
        }
        handPos = targetObject.transform;
        targetHoopPos = targetHoop.transform;

        ball = Balls[0];


        _t += Time.deltaTime;
            float duration = 0.66f;
            float t01 = _t / duration;

            // move to target
            Vector3 A = handPos.position;
            Vector3 B = targetHoopPos.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            // move in arc
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            ball.transform.position = pos + arc;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = true;
            Shoot1();
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Hoop")){
            shootingIsAvailable = false;
            //Debug.Log("exit");
        }
    }

    private void Shoot1(){
        Balls[0].gameObject.SetActive(true);
       
        _notListedBall = Balls[0];
        shootingIsAvailable = false;
        Balls.RemoveAt(0);
        
        Invoke("GetToThePool",1f);  
        _notListedBall.SetActive(true); 
    }
    /*private void Shoot(){
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
        
        Invoke("GetToThePool",1f);  
        _notListedBall.SetActive(true); 
    }*/

    private void GetToThePool(){
        Balls.Add(_notListedBall);
        _notListedBall.transform.position = handPos.position;
        _notListedBall.SetActive(false);
        shootingIsAvailable = true;
    }

}
