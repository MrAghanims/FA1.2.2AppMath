using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    public Transform startPoint;   // Drag your starting position here in Inspector

    void Start()
    {
        // Set initial respawn point to start position
        if (startPoint != null)
            respawnPoint = startPoint.position;
        else
            respawnPoint = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // If player touches a checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
        }

        // If player touches a hazard
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void Update()
    {
        // If player falls off the course (y below -10 for example)
        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPoint;
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset movement
    }
}