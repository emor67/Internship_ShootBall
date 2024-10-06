using System.Collections;
using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float moveDuration = 2f; // Duration to move forward after collision

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
        // Move object in the world space along the global Z axis
        _rb.velocity = new Vector3(0, 0, moveSpeed);

        // Wait for the specified move duration (e.g., 2 seconds)
        yield return new WaitForSeconds(moveDuration);

        // Stop the movement after the duration by setting the velocity to zero
        _rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has collided with something tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Start the coroutine to move the object forward for a set duration
            DisableCollider();
            StartCoroutine(MoveForwardForSeconds());
        }
    }
}
