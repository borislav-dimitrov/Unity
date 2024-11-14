using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharactersManager : MonoBehaviour
{

    public List<GameObject> playableCharacters;
    private GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeCurrentCharacter() {
        currentCharacter = playableCharacters[0];
        GameManager.Instance.playerMovement.Setup(currentCharacter);
    }

    public void ChangeCharacter(int index) {
        if (index <= playableCharacters.Count) {
            SwitchCurrentCharacter(playableCharacters[index]);
            GameManager.Instance.cameraMgr.ChangeFollowObject(currentCharacter);
        }
    }

    private void SwitchCurrentCharacter(GameObject newCharacter) {
        if (newCharacter != null && newCharacter != currentCharacter) {
            currentCharacter.SetActive(false);
            RepositionAllCharacters(currentCharacter.transform.position);
            newCharacter.SetActive(true);

            newCharacter.GetComponent<Rigidbody2D>().velocity = newCharacter.GetComponent<Rigidbody2D>().velocity;
            newCharacter.transform.localScale = currentCharacter.transform.localScale;
            currentCharacter = newCharacter;

            GameManager.Instance.playerMovement.Setup(currentCharacter);
        }
    }

    private void RepositionAllCharacters(Vector2 newPos) {
        foreach (GameObject go in playableCharacters) {
            go.transform.position = newPos;
        }
    }

    public GameObject GetCurrentCharacter() {
        return currentCharacter;
    }
}
