using System.Collections;
using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float moveDuration = 2f; 

    private Rigidbody _rb;
    private Collider _collider;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
         _collider = GetComponent<Collider>();
    }

      void DisableCollider()
    {
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }

    private IEnumerator MoveForwardForSeconds()
    {
        _rb.velocity = new Vector3(0, 0, moveSpeed);

        yield return new WaitForSeconds(moveDuration);

        _rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveForwardForSeconds());
            DisableCollider();
        }
    }
}
