using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float horizontalSpeed;
    public float verticalSpeed;
    public float yaw;
    public float pitch;

    // Update is called once per frame
    void Update()
    {
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y");
        transform.position = player.position + offset;
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);        
    }
}
