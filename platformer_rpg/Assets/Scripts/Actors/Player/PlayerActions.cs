using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public PlayerCharactersController playerCharController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Use(InputAction.CallbackContext context) {
        Debug.Log("Use");
    }

    public void Spell1(InputAction.CallbackContext context) {
        Debug.Log("Spell1");
    }

    public void Spell2(InputAction.CallbackContext context) {
        Debug.Log("Spell2");
    }

    public void Spell3(InputAction.CallbackContext context) {
        Debug.Log("Spell3");
    }

    public void Spell4(InputAction.CallbackContext context) {
        Debug.Log("Spell4");
    }

    public void Spell5(InputAction.CallbackContext context) {
        Debug.Log("Spell5");
    }

    public void SwitchCharacter1(InputAction.CallbackContext context) {
        playerCharController.ChangeCharacter(0);
    }

    public void SwitchCharacter2(InputAction.CallbackContext context) {
        playerCharController.ChangeCharacter(1);
    }

    public void SwitchCharacter3(InputAction.CallbackContext context) {
        playerCharController.ChangeCharacter(2);
    }

    public void SwitchCharacter4(InputAction.CallbackContext context) {
        playerCharController.ChangeCharacter(3);
    }
}
