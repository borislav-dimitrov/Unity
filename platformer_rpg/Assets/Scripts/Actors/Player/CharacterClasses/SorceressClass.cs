using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SorceressClass : BaseClass
{
    public override void Spell1(InputAction.CallbackContext context) {
        Debug.Log("Sorceress Spell 1");
    }

    public override void Spell2(InputAction.CallbackContext context) {
        Debug.Log("Sorceress Spell 2");
    }

    public override void Spell3(InputAction.CallbackContext context) {
        Debug.Log("Sorceress Spell 3");
    }

    public override void Spell4(InputAction.CallbackContext context) {
        Debug.Log("Sorceress Spell 4");
    }
}
