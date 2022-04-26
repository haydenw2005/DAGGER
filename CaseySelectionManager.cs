using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
  public Transform playerAxis;
  public float pickUpRange=5;
  public float moveForce = 250;
  public Transform holdParent;

  private bool inCar;
  private GameObject heldobj;

  public HoverFollowCam HoverFollowCam;
  Camera m_MainCamera;
  // Start is called before the first frame update
  void Start()
  {
      //This gets the Main Camera from the Scene
      m_MainCamera = Camera.main;
      //This enables Main Camera
      m_MainCamera.enabled = true;
      //Use this to disable secondary Camera
      HoverFollowCam.enabled = false;
      inCar = HoverFollowCam.enabled;
  }

  // Update is called once per frame

  void Update()
  {
    if (heldobj == null)
    {
      RaycastHit select;
      if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out select, pickUpRange))
      {
        if(select.transform.gameObject.tag == "Selectable" || select.transform.gameObject.tag == "Player")
        {
          select.collider.SendMessage("HitByRay", SendMessageOptions.DontRequireReceiver);
        }
      }
    }
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (heldobj == null && inCar == false)
      {
        RaycastHit hit;
        if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out hit, pickUpRange))
        {
          if(hit.transform.gameObject.tag == "Selectable")
          {
            PickupObject(hit.transform.gameObject);
          }
          else if(hit.transform.gameObject.tag == "Player")
          {
            Debug.Log("Lemme in");
            getInCar();
          }
          else if(hit.transform.gameObject.name == "Toon Chicken")
          {
            Debug.Log("chickendeath");
            hit.transform.gameObject.SendMessage("KillChicken", SendMessageOptions.DontRequireReceiver);
          }
        }
      }
      else
      {
        if(heldobj != null)
        {
          DropObject();
        }
        else
        {
          getOutCar();
        }
      }
    }
    if (heldobj != null)
    {
        MoveObject();
    }
  }

  void MoveObject()
  {
    if(Vector3.Distance(heldobj.transform.position, holdParent.position) > 0.1f)
    {
      Vector3 moveDirection = (holdParent.position - heldobj.transform.position);
      heldobj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
    }
  }

  void PickupObject (GameObject pickobj)
  {
    if (pickobj.GetComponent<Rigidbody>())
    {
      Rigidbody objRig = pickobj.GetComponent<Rigidbody>();
      Collider objCollide = pickobj.GetComponent<Collider>();
      objCollide.enabled = false;
      objRig.useGravity = false;
      objRig.drag = 10;
      objRig.transform.parent = holdParent;
      heldobj = pickobj;
    }
  }

  void DropObject()
  {
    Rigidbody heldRig = heldobj.GetComponent<Rigidbody>();
    Collider heldCollide = heldobj.GetComponent<Collider>();
    heldCollide.enabled = true;
    heldRig.useGravity = true;
    heldRig.drag = 1;
    heldobj.transform.parent= null;
    heldobj= null;
  }

  void getInCar()
  {
    if (inCar == false)
    {
        //Enable the second Camera
        HoverFollowCam.enabled = true;
        //The Main first Camera is disabled
        m_MainCamera.enabled = false;
    }
    inCar = true;
  }

  void getOutCar()
  {
    if (inCar == true)
    {
        //disable the second Camera
        HoverFollowCam.enabled = false;
        //The Main first Camera is enabled
        m_MainCamera.enabled = true;
    }
    inCar = false;
  }

}
