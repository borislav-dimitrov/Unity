using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TechnomancerClass : BaseClass
{
    [SerializeField] private HackArea hackArea;

    public override void Attack() {
        Debug.Log($"Technomancer Attack {attackType} {attackDamageModifier}");
    }

    public override void Spell1(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        // Hack
        if (hackArea.GetHackableInRadius()) {
            Debug.Log($"Starting to hack {hackArea.GetHackableInRadius().name}...");
        }
    }

    public override void Spell2(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        ClearTechnomancerBuffs();
        TechnomancerHpReg hpReg = new(regAmount: 15, duration: 60);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(hpReg);
    }

    public override void Spell3(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        ClearTechnomancerBuffs();
        TechnomancerMaxHp maxHp = new(maxHpPerc: 10, duration: 10);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(maxHp);
    }

    public override void Spell4(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        ClearTechnomancerBuffs();
        TechnomancerDR dr = new(reduction: 5, duration: 60);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(dr);
    }


    private void ClearTechnomancerBuffs() {
        GameManager.Instance.statusEffectMgr.RemovePlayerBuff(BuffIds.technomancerHpReg);
        GameManager.Instance.statusEffectMgr.RemovePlayerBuff(BuffIds.technomancerMaxHP);
        GameManager.Instance.statusEffectMgr.RemovePlayerBuff(BuffIds.technomancerDR);
    }
}
