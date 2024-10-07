using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    public float stopDuration = 2f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation; 
    }

    void Update()
    {
        
    }

    private IEnumerator StopForSeconds()
    {
        _rb.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(stopDuration);

        _rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stop"))
        {
            StartCoroutine(StopForSeconds());
        }
    }
}
