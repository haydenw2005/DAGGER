using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    public Transform playerStats;
    //public Transform bikeStats;
    private Vector3 dir;
    public Text compassText;

    void Start()
    {
        compassText.text = "hi";
    }

    // Update is called once per frame
    void Update() // N->E
    {
        dir.z = playerStats.eulerAngles.y;
        //float rotY = playerStats.transform.rotation.y;
        if (dir.z > 337.5 || dir.z < 22.5) {
            compassText.text = "W";
        }
        else if (dir.z > 22.5 && dir.z < 67.5) {
            compassText.text = "NW";
        }
        else if (dir.z > 67.5 && dir.z < 113.5) {
            compassText.text = "N";
        }
        else if (dir.z > 113.5 && dir.z < 158.5) {
            compassText.text = "NE";
        }
        else if (dir.z > 158.5 && dir.z < 203.5) {
            compassText.text = "E";
        }
        else if (dir.z > 203.5 && dir.z < 248.5) {
            compassText.text = "SE";
        }
        else if (dir.z > 248.5 && dir.z < 293.5) {
            compassText.text = "S";
        }
        else if (dir.z > 293.5 && dir.z < 338.5) {
            compassText.text = "SW";
        }
    }
}
