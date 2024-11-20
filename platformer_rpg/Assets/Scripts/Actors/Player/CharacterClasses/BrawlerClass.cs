using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrawlerClass : BaseClass
{
    [Header("Spells")]
    public Shockwave shockwave;

    public override void Attack() {
        Debug.Log($"Brawler Attack {attackType} {attackDamageModifier}");
    }

    public override void Spell1(InputAction.CallbackContext context) {
        CastSpell(context, shockwave.requiredCastTime, () => {shockwave.Cast();});
    }

    public override void Spell2(InputAction.CallbackContext context) {
        Debug.Log("Brawler Spell 2");
    }

    public override void Spell3(InputAction.CallbackContext context) {
        Debug.Log("Brawler Spell 3");
    }

    public override void Spell4(InputAction.CallbackContext context) {
        Debug.Log("Brawler Spell 4");
    }
}
