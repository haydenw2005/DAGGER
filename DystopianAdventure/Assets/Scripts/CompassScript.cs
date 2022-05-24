using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    public Transform playerStats;
    //public Transform bikeStats;
    private Vector3 dir;
    private Vector3 dir2;
    public Text compassText;
    public bool inCar;
    public GameObject hoverCar;
    private HoverCarControl anInstance;

    void Start()
    {
        compassText.text = "hi";
        anInstance = hoverCar.GetComponent<HoverCarControl>();
    }

    // Update is called once per frame
    void Update() // N->E
    {
        inCar = anInstance.getStatus();

        dir.z = playerStats.eulerAngles.y;
        dir2.z = hoverCar.transform.eulerAngles.y;

        if(!inCar) {
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
        else {
            if (dir2.z > 337.5 || dir2.z < 22.5) {
                compassText.text = "W";
            }
            else if (dir2.z > 22.5 && dir2.z < 67.5) {
                compassText.text = "NW";
            }
            else if (dir2.z > 67.5 && dir2.z < 113.5) {
                compassText.text = "N";
            }
            else if (dir2.z > 113.5 && dir2.z < 158.5) {
                compassText.text = "NE";
            }
            else if (dir2.z > 158.5 && dir2.z < 203.5) {
                compassText.text = "E";
            }
            else if (dir2.z > 203.5 && dir2.z < 248.5) {
                compassText.text = "SE";
            }
            else if (dir2.z > 248.5 && dir2.z < 293.5) {
                compassText.text = "S";
            }
            else if (dir2.z > 293.5 && dir2.z < 338.5) {
                compassText.text = "SW";
            }
        }
        
    }
}
