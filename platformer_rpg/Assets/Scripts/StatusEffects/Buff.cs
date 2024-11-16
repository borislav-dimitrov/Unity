using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public int buffId;
    public string effectName;
    public string description;
    public float duration;
    public bool isAlive;

    protected Action onUseEffect;
    protected Action onDisappear;

    public Buff(
        int buffId, string effectName, string description, float duration,
         Action onUseEffect, Action onDisappear
    ) {
        this.buffId = buffId;
        this.effectName = effectName;
        this.description = description;
        this.duration = duration;
        this.onUseEffect = onUseEffect;
        this.onDisappear = onDisappear;
        isAlive = true;
    }

    public void UseEffect() {
        onUseEffect();
    }

    public void Disappear() {
        isAlive = false;
        onDisappear();
    }

    public void Tick() {
        duration -= 1;

        if (duration <= 0) {
            isAlive = false;
        }
    }
}

public class TechnomancerHpReg : Buff {

    public TechnomancerHpReg(int regAmount, int duration) : base(
        buffId: BuffIds.technomancerHpReg,
        effectName: BuffNames.technomancerHpReg,
        description: $"Increase Player Health Regeneration by {regAmount}",
        duration: duration,
        onUseEffect: () => {
            GameManager.Instance.statusEffectMgr.playerStats.healthRegen += regAmount;
        },
        onDisappear: () => {
            GameManager.Instance.statusEffectMgr.playerStats.healthRegen -= regAmount;
        }
    ) {}
}

public class TechnomancerMaxHp : Buff {
    public TechnomancerMaxHp(float maxHpPerc, int duration) : base(
        buffId: BuffIds.technomancerMaxHP,
        effectName: BuffNames.technomancerMaxHP,
        description: $"Increase Player Maximum Health by {maxHpPerc}",
        duration: duration,
        onUseEffect: () => {
            GameManager.Instance.statusEffectMgr.playerStats.IncMaxHpPerc(maxHpPerc);
        },
        onDisappear: () => {
            GameManager.Instance.statusEffectMgr.playerStats.DecMaxHpPerc(maxHpPerc);
        }
    ) {}
}

public class TechnomancerDR : Buff {
    public TechnomancerDR(int reduction, int duration) : base(
        buffId: BuffIds.technomancerDR,
        effectName: BuffNames.technomancerDR,
        description: $"Increase Player Damage Reduction by {reduction}",
        duration: duration,
        onUseEffect: () => {
            GameManager.Instance.statusEffectMgr.playerStats.damageReduction += reduction;
        },
        onDisappear: () => {
            GameManager.Instance.statusEffectMgr.playerStats.damageReduction -= reduction;
        }
    ) {}
}

public static class BuffIds {
    public static readonly int technomancerHpReg = 0;
    public static readonly int technomancerMaxHP = 0;
    public static readonly int technomancerDR = 0;
}

public static class BuffNames {
    public static readonly string technomancerHpReg = "Health Regeneration";
    public static readonly string technomancerMaxHP = "Increased Maximum Health";
    public static readonly string technomancerDR = "Damage Reduction";
}
