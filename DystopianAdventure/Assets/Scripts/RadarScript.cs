using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScript : MonoBehaviour
{
    public bool isActivated = false;
    public Transform mainCamAxis;
    public float pickUpRange = 10;
    public Light radarLight;
    public GameObject radarBody;

    public bool turnOnRadar() {
        if (isActivated == false && Input.GetKey(KeyCode.E)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCamAxis.transform.position, mainCamAxis.transform.forward, out hit, pickUpRange))
            {
                Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.name == "Radar")
                {
                    isActivated = true;
                    Debug.Log("Activated");
                    radarBody.GetComponent<Animator>().enabled = true;
                    radarLight.color = Color.green;
                    GameObject.Find("/Canvas/AliveUI/ImportantUI/GuideHint").SendMessage("MissionOne");
                    //ps.Play();
                    return true;
                }
            }
        }
        return false;
    }
}
