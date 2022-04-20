using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
  public Transform playerAxis;
  public float pickUpRange=5;
  public float moveForce = 250;
  public Transform holdParent;

  private GameObject heldobj;
  // Update is called once per frame

  //hover car stuff
  public HoverFollowCam HoverFollowCam;
  Camera m_MainCamera; 
  public GameObject hoverCar;
  // Start is called before the first frame update
  void Start()
  {
      //This gets the Main Camera from the Scene
      m_MainCamera = Camera.main;
      //This enables Main Camera
      m_MainCamera.enabled = true;
      //Use this to disable secondary Camera
      HoverFollowCam.enabled = false;
      item.disable = true;

  }

  void Update()
  {
    if (heldobj == null)
    {
      RaycastHit select;
      if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out select, pickUpRange))
      {
        if(select.transform.gameObject.tag == "Selectable" || select.transform.gameObject.tag == "hoverCar")
        {
          select.collider.SendMessage("HitByRay", SendMessageOptions.DontRequireReceiver);
        }
      }
    }
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (heldobj == null)
      {
        RaycastHit hit;
        if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out hit, pickUpRange))
        {
          if(hit.transform.gameObject.tag == "Selectable")
          {
            PickupObject(hit.transform.gameObject);
          }
          else if(hit.transform.gameObject.tag == "hoverCar")
          {
            getInCar(hit.transform.gameObject);
          }
        }
      }
      else
      {
        DropObject();
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

  void getInCar(GameObject hoverCar)
  {
    //Check that the Main Camera is enabled in the Scene, then switch to the other Camera on a key press
    if (m_MainCamera.enabled)
    {
        //Enable the second Camera
        HoverFollowCam.enabled = true;

        //The Main first Camera is disabled
        m_MainCamera.enabled = false;
    }
    //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
    else if (!m_MainCamera.enabled)
    {
        //Disable the second camera
        HoverFollowCam.enabled = false;

        //Enable the Main Camera
        m_MainCamera.enabled = true;
    }
  }

}
