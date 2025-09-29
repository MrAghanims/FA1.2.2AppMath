using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation
    public float pushForce = 5f; // How strong it pushes the player

    void Update()
    {
        // Rotate obstacle
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Direction from obstacle center to player
                Vector3 pushDir = (collision.transform.position - transform.position).normalized;

                // Apply a gentle force
                rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            }
        }
    }
}