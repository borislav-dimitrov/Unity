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
    }

    // Start is called before the first frame update
    void Start()
    {
        charMgr.InitializeCurrentCharacter();
        cameraMgr.ChangeFollowObject(charMgr.GetCurrentCharacter());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
