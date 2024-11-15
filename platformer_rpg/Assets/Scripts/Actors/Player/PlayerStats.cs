using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5;

    [Header("Jump")]
    public float jumpPower = 8;
    public int maxJumps = 2;

    [Header("Gravity")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18;
    public float fallSpeedMultiplier = 2;

    [Header("Resources")]
    public int healthPool = 100;
    public int healthRegen = 0;
    public int manaPool = 0;

    [Header("Combat")]
    public int attackDamage = 25;
    public AttackTypes attackType = AttackTypes.None;


    private void ResetPlayerStats() {
        moveSpeed = 5;
        jumpPower = 8;
        maxJumps = 2;
        baseGravity = 2;
        maxFallSpeed = 18;
        fallSpeedMultiplier = 2;
        healthPool = 100;
        healthRegen = 0;
        manaPool = 0;
        attackDamage = 25;
        attackType = AttackTypes.None;
    }

    public void ApplyCharacterModifiers(BaseClass characterClass) {
        ResetPlayerStats();

        moveSpeed += characterClass.moveSpeedModifier;
        jumpPower += characterClass.jumpPowerModifier;
        maxJumps += characterClass.maxJumpsModifier;
        baseGravity += characterClass.baseGravityModifier;
        maxFallSpeed += characterClass.maxFallSpeedModifier;
        fallSpeedMultiplier += characterClass.fallSpeedMultiplier;
        healthPool += characterClass.healthPoolModifier;
        healthRegen += characterClass.healthRegenModifier;
        manaPool += characterClass.manaPoolModifier;
        attackDamage += characterClass.attackDamageModifier;
        attackType = characterClass.attackType;
    }
}
