using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerCharactersManager charMgr;
    public CameraManager cameraMgr;
    public StatusEffectManager statusEffectMgr;

    public PlayerMovement playerMovement;
    public PlayerActions playerActions;
    // camera mgr

    void Awake() {
        Instance = this;
        charMgr.InitializeCurrentCharacter();
        cameraMgr.ChangeFollowObject(charMgr.GetCurrentCharacter());
    }
}
