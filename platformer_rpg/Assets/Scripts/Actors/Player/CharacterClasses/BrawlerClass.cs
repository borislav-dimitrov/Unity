using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerClass : BaseClass
{
    [Header("Spells")]
    public Shockwave shockwave;

    public override void Attack() {
        Debug.Log($"Brawler Attack {attackType} {attackDamageModifier}");
    }

    public override void Spell1() {
        shockwave.Cast();
    }

    public override void Spell2() {
        Debug.Log("Brawler Spell 2");
    }

    public override void Spell3() {
        Debug.Log("Brawler Spell 3");
    }

    public override void Spell4() {
        Debug.Log("Brawler Spell 4");
    }
}
