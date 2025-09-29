using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 100f;
    public Vector3 scaleChange = new Vector3(1.2f, 1.2f, 1.2f);

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool isScaled = false;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found! Please add a Rigidbody to the player.");
        }

        originalScale = transform.localScale;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Make the shooter face the movement direction
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // --- Jump with Space ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // --- Spin clockwise while holding X ---
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // --- Toggle scale with Y ---
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isScaled)
                transform.localScale = originalScale;
            else
                transform.localScale = originalScale + scaleChange;

            isScaled = !isScaled;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Checkpoint"))
        {
            isGrounded = true;
        }
    }
}