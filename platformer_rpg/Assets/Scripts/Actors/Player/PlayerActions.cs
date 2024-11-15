using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        Debug.Log("Use");
    }

    public void Attack(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.GetCurrentCharacter().GetComponent<BaseClass>().Attack();
    }

    public void Spell1(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.GetCurrentCharacter().GetComponent<BaseClass>().Spell1();
    }

    public void Spell2(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.GetCurrentCharacter().GetComponent<BaseClass>().Spell2();
    }

    public void Spell3(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.GetCurrentCharacter().GetComponent<BaseClass>().Spell3();
    }

    public void Spell4(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.GetCurrentCharacter().GetComponent<BaseClass>().Spell4();
    }

    public void SwitchCharacter1(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.ChangeCharacter(0);
    }

    public void SwitchCharacter2(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.ChangeCharacter(1);
    }

    public void SwitchCharacter3(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.ChangeCharacter(2);
    }

    public void SwitchCharacter4(InputAction.CallbackContext context) {
        if (!context.canceled) return;
        GameManager.Instance.charMgr.ChangeCharacter(3);
    }
}
