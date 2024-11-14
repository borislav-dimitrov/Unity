using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackArea : MonoBehaviour
{
    private GameObject hackableInRadius;

    public GameObject GetHackableInRadius() {
        return hackableInRadius;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Hackable")) {
            if (other.gameObject != hackableInRadius) {
                hackableInRadius = other.gameObject;
            }
            Debug.Log($"You can start hacking {hackableInRadius.name}");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == hackableInRadius) {
            hackableInRadius = null;
            Debug.Log($"You left hacking area for {other.gameObject.name}");
        }
    }
}
