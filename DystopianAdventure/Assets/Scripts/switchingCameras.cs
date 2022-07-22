using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCameras : MonoBehaviour
{
    private Camera firstPersonCamera;
    private Camera hoverCamera;

    // Call this function to disable FPS camera,
    // and enable hover camera.
    public void ShowHoverView() {
        firstPersonCamera.enabled = false;
        hoverCamera.enabled = true;
    }
    
    // Call this function to enable FPS camera,
    // and disable hover camera.
    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        hoverCamera.enabled = false;
    }
}
