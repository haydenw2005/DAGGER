using UnityEngine;
using System.Collections;

public class HoverFollowCam : MonoBehaviour
{
  float m_camHeight;
  float m_camDist;
  GameObject m_player;
  int m_layerMask;
  public GameObject bike;

  void Start()
  {
    m_player = GameObject.FindGameObjectWithTag("Player") as GameObject;

    Vector3 offsetCam = transform.position - m_player.transform.position;
    m_camHeight = offsetCam.y;
    m_camDist = Mathf.Sqrt(
      offsetCam.x * offsetCam.x +
      offsetCam.z * offsetCam.z);

    m_layerMask = 1 << LayerMask.NameToLayer("Characters");
    m_layerMask = ~m_layerMask;
  }

  void Update()
  {
    Vector3 camOffset = -m_player.transform.forward;
    camOffset = new Vector3(camOffset.x, 0.0f, camOffset.z) * m_camDist
      + Vector3.up * m_camHeight;

    RaycastHit hitInfo;
    if (Physics.Raycast(m_player.transform.position, camOffset,
                       out hitInfo, m_camDist,
                       m_layerMask))
    {
      transform.position = m_player.transform.position + new Vector3(0.0f, 5.0f, 0.0f);
      //transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
    } else
    {
      transform.position = m_player.transform.position + new Vector3(0.0f, 5.0f, 0.0f);
    }

    transform.LookAt(m_player.transform.position + new Vector3(0.0f, 5f, 0.0f));
    //MAKE IT SO LOOKAT POINTS BETWEEN TWO FRONT HOVER POINTS
  }
}
