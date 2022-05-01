using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E)) {
            //player = GameObject.Find("FirstPersonPlayer");
            //player.TakeHunger(-10);
            Destroy(gameObject);
        }
    }
}
