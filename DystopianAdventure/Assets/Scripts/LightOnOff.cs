using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
  public Transform sun;
  public Light sunlight;

  void Update()
  {
    if(sun.transform.position.y < 0)
    {
      sunlight.enabled = false;
    }
    else
    {
      sunlight.enabled = true;
    }
  }
}
