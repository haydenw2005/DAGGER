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
    Debug.Log("vroom");
  }

}
