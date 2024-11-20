using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public PlayerStats playerStats;
    private List<Buff> charBuffs = new();
    private List<Buff> playerBuffs = new();
    private List<Debuff> playerDebuffs = new();
    private List<Disable> playerDisables = new();

    private float tickInterval = 1f;
    private float timePassed = 0f;
    private List<Buff> buffsToBeRemoved = new();


    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > tickInterval) {
            timePassed = 0f;

            ProcessBuffs(charBuffs);
            ProcessBuffs(playerBuffs);
            ProcessPlayerDebuffs();
            ProcessPlayerDisables();
        }
    }


    public void AddCharBuff(Buff buff) {
        foreach (Buff charBuff in charBuffs) {
            if (charBuff.buffId == buff.buffId) {
                charBuff.Disappear();
                charBuffs.Remove(charBuff);
                break;
            }
        }

        charBuffs.Add(buff);
        buff.UseEffect();

        Debug.Log($"++ {buff.effectName}");
    }

    public void RemoveCharBuff(int buffId) {
        foreach (Buff buff in charBuffs) {
            if (buff.buffId == buffId) {
                Debug.Log($"-- {buff.effectName}");
                buff.Disappear();
                charBuffs.Remove(buff);
                break;
            }
        }
    }

    public void AddPlayerBuff(Buff buff) {
        foreach (Buff playerBuff in playerBuffs) {
            if (playerBuff.buffId == buff.buffId) {
                playerBuff.Disappear();
                playerBuffs.Remove(playerBuff);
                break;
            }
        }

        playerBuffs.Add(buff);
        buff.UseEffect();
        Debug.Log($"++ {buff.effectName}");
    }

    public void RemovePlayerBuff(int buffId) {
        foreach (Buff buff in playerBuffs) {
            if (buff.buffId == buffId) {
                Debug.Log($"-- {buff.effectName}");
                buff.Disappear();
                playerBuffs.Remove(buff);
                break;
            }
        }
    }

    public void AddPlayerDebuff(Debuff debuff) {

    }

    public void AddPlayerDisable(Disable disable) {

    }

    private void ProcessBuffs(List<Buff> buffsToProcess) {
        foreach(Buff buff in buffsToProcess) {
            buff.Tick();

            if (!buff.isAlive) {
                buff.Disappear();
                buffsToBeRemoved.Add(buff);
            }
        }

        foreach(Buff buff in buffsToBeRemoved) {
            buffsToProcess.Remove(buff);
        }

        buffsToBeRemoved.Clear();
    }

    private void ProcessPlayerDebuffs() {

    }

    private void ProcessPlayerDisables() {

    }

    public void ApplyCharacterModifiersAndPersistBuffs(BaseClass characterClass) {
        playerStats.ApplyCharacterModifiers(characterClass);

        foreach (Buff buff in playerBuffs) {
            buff.UseEffect();
        }
    }
}
