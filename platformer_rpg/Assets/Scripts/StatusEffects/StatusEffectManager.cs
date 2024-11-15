using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
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
