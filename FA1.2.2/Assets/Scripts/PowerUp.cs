using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float shrinkFactor = 0.5f;   // 50% smaller
    public float duration = 5f;         // how long the effect lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Scale the root object, not just the collider
            Transform playerRoot = other.transform.root;
            playerRoot.localScale *= shrinkFactor;

            // Reset after a duration
            StartCoroutine(ResetSize(playerRoot));

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator ResetSize(Transform playerRoot)
    {
        yield return new WaitForSeconds(duration);
        playerRoot.localScale = Vector3.one; // reset to default (1,1,1)
    }
}