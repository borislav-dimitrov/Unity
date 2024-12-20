using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AttackTypes {
    None, Melee, Range
}

public class BaseClass : MonoBehaviour
{
    /// <summary>
    /// This is the BaseClass that needs to be overriden by the other character classes
    /// </summary>
    public string className = "Base";
    public float moveSpeedModifier = 0;
    public float jumpPowerModifier = 0;
    public int maxJumpsModifier = 0;
    public float baseGravityModifier = 0;
    public float maxFallSpeedModifier = 0;
    public float fallSpeedMultiplier = 0;
    public int healthPoolModifier = 0;
    public int healthRegenModifier = 0;
    public float maxHealtPercModifier = 0;
    public int manaPoolModifier = 0;
    public int attackDamageModifier = 0;
    public int damageReductionModifier = 0;
    public AttackTypes attackType = AttackTypes.None;


    private double startCastTime = 0;

    public virtual void Attack() {
        throw new NotImplementedException();
    }

    public virtual void Spell1(InputAction.CallbackContext context) {
        throw new NotImplementedException();
    }

    public virtual void Spell2(InputAction.CallbackContext context) {
        throw new NotImplementedException();
    }

    public virtual void Spell3(InputAction.CallbackContext context) {
        throw new NotImplementedException();
    }

    public virtual void Spell4(InputAction.CallbackContext context) {
        throw new NotImplementedException();
    }

    public void ModifyPlayerStats() {
        GameManager.Instance.statusEffectMgr.ApplyCharacterModifiersAndPersistBuffs(this);
    }

    protected void CastSpell(InputAction.CallbackContext context, double reqCastTime, Action onSuccess) {
        if (context.performed) startCastTime = context.startTime;
        if (context.canceled) {
            double castTime = context.time - startCastTime;
            startCastTime = 0;
            if (castTime >= reqCastTime){
                onSuccess();
            } else {
                Debug.Log($"Cast failed! Cast time - {castTime}");
            }
        }
    }
}
