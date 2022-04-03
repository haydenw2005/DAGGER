using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
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
