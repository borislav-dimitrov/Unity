using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackTypes {
    None, Melee, Range
}

public class BaseClass : MonoBehaviour
{
    /// <summary>
    /// This is the BaseClass that needs to be overriden by the other character classes
    /// </summary>
    public string className = "Base";
    public float moveSpeed = 5;
    public float jumpPower = 8;
    public float baseGravity = 2;
    public float maxFallSpeed = 18;
    public float fallSpeedMultiplier = 2;
    public int healthPool = 100;
    public int? manaPool = null;
    public AttackTypes attackType = AttackTypes.None;
    public int attackDamage = 25;

    public List<Buff> buffs = new List<Buff>();
    public List<Debuff> debuffs = new List<Debuff>();
    public List<Disable> disables = new List<Disable>();

    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void Attack() {
        throw new NotImplementedException();
    }

    public virtual void Spell1() {
        throw new NotImplementedException();
    }

    public virtual void Spell2() {
        throw new NotImplementedException();
    }

    public virtual void Spell3() {
        throw new NotImplementedException();
    }

    public virtual void Spell4() {
        throw new NotImplementedException();
    }
}
