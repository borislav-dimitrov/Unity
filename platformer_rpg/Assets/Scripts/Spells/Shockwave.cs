using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D hitBox;
    public readonly double requiredCastTime = 2;

    private List<GameObject> objectsHit = new();

    void Awake() {
        animator = GetComponent<Animator>();
        hitBox = GetComponent<CapsuleCollider2D>();
    }

    public string GetDescription() {
        string description = "Dealse heavy Area of Effect damage.\n";
        description += $"Damage: {GetDamage()}\n";
        description += "HINT: May break stuff.";
        return description;
    }

    private int GetDamage() {
        // TODO - update the this to take accoutn for character level when implemented
        return 50;
    }

    public void Cast() {
        hitBox.enabled = true;
        animator.SetTrigger("cast");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") || other.CompareTag("Breakable")) {
            objectsHit.Add(other.gameObject);
        }
    }

    private void OnCastEnd() {
        hitBox.enabled = false;

        foreach (GameObject obj in objectsHit) {
            Debug.Log(obj.name);
        }
    }
}
