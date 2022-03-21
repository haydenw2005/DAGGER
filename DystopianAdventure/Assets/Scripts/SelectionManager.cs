using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Transform playerAxis;

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;
      if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out hit))
      {
        hit.transform.SendMessage ("HitByRay");
      }
    }
}
