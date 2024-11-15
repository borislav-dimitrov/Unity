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

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessBuffs(charBuffs);
        ProcessBuffs(playerBuffs);
        ProcessPlayerDebuffs();
        ProcessPlayerDisables();
    }


    public void AddCharBuff(Buff buff) {

    }

    public void AddPlayerBuff(Buff buff) {
        foreach (Buff charBuff in charBuffs) {
            if (charBuff.buffId == buff.buffId) {
                charBuffs.Remove(buff);
                break;
            }
        }

        charBuffs.Add(buff);
    }

    public void AddPlayerDebuff(Debuff debuff) {

    }

    public void AddPlayerDisable(Disable disable) {

    }

    private void ProcessBuffs(List<Buff> buffsToProcess) {
        // foreach(Buff buff in buffsToProcess) {
        //     if (buff.isAlive) {
        //         buff.OnDisappear();
        //         buffsToProcess.Remove(buff);
        //     }
        // }
    }

    private void ProcessPlayerDebuffs() {

    }

    private void ProcessPlayerDisables() {

    }
}
