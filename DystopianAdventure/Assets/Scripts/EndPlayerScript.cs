using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//End player script which defines characteristics for player in the hallway scene
public class EndPlayerScript : MonoBehaviour
{
    public GameObject pauseMenu;

    //Mouse cursor attribute
    void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        //toggle pause menu
        if (Input.GetKeyDown("escape"))
            {
                if (!pauseMenu.activeSelf) {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                } else {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            }
    }

    //check if layer hit door
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "DoorCollision")
        {
            SceneManager.LoadScene(3);
        }
    }
}
