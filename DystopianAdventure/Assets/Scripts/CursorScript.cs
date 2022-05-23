using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script which defines the cursor behavior.
public class CursorScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //If pause menu is active, show cursor. If not, don't
    void Update()
    {
        if (pauseMenu.activeSelf == true) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else if (pauseMenu.activeSelf == false) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            

        }
    }
}
