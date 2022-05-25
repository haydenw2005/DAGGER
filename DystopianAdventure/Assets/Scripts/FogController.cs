using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogColor = Color.blue;
        RenderSettings.fog = true;
    }
}
