using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class PlayerData 
{
    public float[] playerPosition;
    public float playerAngle; 
    //public float[] angle;
    //public int ohbrotha;
    public int health;
    public int hunger;

    public PlayerData (PlayerMain player) {
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;

        playerAngle = player.transform.rotation.eulerAngles.y;
        

        //angle = new float[3];
        //angle[0] = player.transform.rotation.x;
        //angle[1] = player.transform.rotation.y;
        //angle[2] = player.transform.rotation.z;

        health = player.currentHealth;
        hunger = player.currentHunger;
    }


}
