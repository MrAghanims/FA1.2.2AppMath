using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Drag your player here in Inspector
    public Vector3 offset;          // Set offset (e.g., new Vector3(0, 5, -10))
    public float smoothSpeed = 5f;  // Adjust for smoother follow

    void LateUpdate()
    {
        if (player == null) return;

        // Desired position = player position + offset
        Vector3 desiredPosition = player.position + offset;

        // Smooth movement (lerp for smoothing)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Make camera look at player (optional)
        transform.LookAt(player);
    }
}