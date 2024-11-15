using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public int buffId;
    public string effectName;
    public float duration;
    public bool isAlive;

    public Buff(int buffId, string effectName, float duration) {
        this.buffId = buffId;
        this.effectName = effectName;
        this.duration = duration;
    }

    public virtual void Effect() {
        throw new NotImplementedException();
    }

    public virtual void OnDisappear() {
        throw new NotImplementedException();
    }
}


public class IncreasedHealthRegen : Buff {
    private float ammountHpRegen;
    public IncreasedHealthRegen(float duration, float ammountHpRegen) : base(0, "Increased Health Regeneration", duration) {
        this.ammountHpRegen = ammountHpRegen;
    }

    public override void Effect() {
        Debug.Log($"Providing {ammountHpRegen} {this.effectName} for {this.duration} seconds");
    }
}
