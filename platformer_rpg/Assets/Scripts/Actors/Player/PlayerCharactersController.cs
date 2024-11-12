using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharactersController : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;

    public List<GameObject> playableCharacters;
    private GameObject currentCharacter;
    private PlayerControls playerControls;
    private PlayerActions playerActions;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = playableCharacters[0];
        playerControls = transform.GetComponent<PlayerControls>();
        playerActions = transform.GetComponent<PlayerActions>();
        playerActions.playerCharController = this;

        playerControls.currentCharacterRB = currentCharacter.GetComponent<Rigidbody2D>();
        playerControls.animator = currentCharacter.GetComponent<Animator>();
        playerControls.groundCheckPos = currentCharacter.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (cinemachineCamera.Follow != currentCharacter.transform) {
            cinemachineCamera.Follow = currentCharacter.transform;
        }
    }

    public void ChangeCharacter(int index) {
        if (index <= playableCharacters.Count) {
            SwitchCurrentCharacter(playableCharacters[index]);
        }
    }

    private void SwitchCurrentCharacter(GameObject newCharacter) {
        if (newCharacter != null && newCharacter != currentCharacter) {
            currentCharacter.SetActive(false);
            RepositionAllCharacters(currentCharacter.transform.position);
            newCharacter.SetActive(true);
            currentCharacter = newCharacter;
            playerControls.currentCharacterRB = currentCharacter.GetComponent<Rigidbody2D>();
            playerControls.animator = currentCharacter.GetComponent<Animator>();
            playerControls.groundCheckPos = currentCharacter.transform.GetChild(0);
        }
    }

    private void RepositionAllCharacters(Vector2 newPos) {
        foreach (GameObject go in playableCharacters) {
            go.transform.position = newPos;
        }
    }
}
