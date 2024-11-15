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

    private Action onUseEffect;
    private Action onDisappear;

    public Buff(
        int buffId, string effectName, float duration,
         Action onUseEffect, Action onDisappear
    ) {
        this.buffId = buffId;
        this.effectName = effectName;
        this.duration = duration;
        this.onUseEffect = onUseEffect;
        this.onDisappear = onDisappear;
    }

    public virtual void UseEffect() {
        onUseEffect();
    }

    public virtual void Disappear() {
        isAlive = false;
        onDisappear();
    }
}

public static class BuffIds {
    public static readonly int hpReg = 0;
}

public static class BuffNames {
    public static readonly string hpReg = "Health Regeneration";
}

// public class IncreasedHealthRegen : Buff {
//     private float ammountHpRegen;

//     public IncreasedHealthRegen(
//         float duration, float ammountHpRegen,
//         Action onUseEffect, Action onDisappear
//     ) : base(
//         0, "Increased Health Regeneration", duration,
//         onUseEffect, onDisappear
//     ) {
//         this.ammountHpRegen = ammountHpRegen;
//     }
// }
