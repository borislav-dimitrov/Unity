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
        // Buff 1
        IncreasedHealthRegen hpReg = new IncreasedHealthRegen(3, 10);
        GameManager.Instance.statusEffectMgr.AddPlayerBuff(hpReg);
    }

    public override void Spell3() {
        Debug.Log("Technomancer Spell 3");
    }

    public override void Spell4() {
        Debug.Log("Technomancer Spell 4");
    }


}
