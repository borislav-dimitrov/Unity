using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnomancerClass : BaseClass
{
    [SerializeField] private HackArea hackArea;

    public override void Attack() {
        Debug.Log($"Brawler Attack {attackType} {attackDamageModifier} {healthPoolModifier}");
    }

    public override void Spell1() {
        // Hack
        if (hackArea.GetHackableInRadius()) {
            Debug.Log($"Starting to hack {hackArea.GetHackableInRadius().name}...");
        }
    }

    public override void Spell2() {
        ClearTechnomancerBuffs();
        TechnomancerHpReg hpReg = new(regAmount: 15, duration: 60);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(hpReg);
    }

    public override void Spell3() {
        ClearTechnomancerBuffs();
        TechnomancerMaxHp maxHp = new(maxHpPerc: 10, duration: 10);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(maxHp);
    }

    public override void Spell4() {
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
