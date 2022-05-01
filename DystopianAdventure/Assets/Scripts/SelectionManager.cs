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

    RaycastHit select;
    if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out select, pickUpRange))
    {
      if(select.transform.gameObject.tag == "Selectable" || select.transform.gameObject.tag == "Player")
      {
        select.collider.SendMessage("HitByRay", SendMessageOptions.DontRequireReceiver);
      }
    }

    if (Input.GetKeyDown(KeyCode.E))
    {
      RaycastHit hit;
      if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out hit, pickUpRange))
      {
        if(hit.transform.gameObject.tag == "Selectable" && hit.transform.gameObject.TryGetComponent<ItemObject>(out ItemObject item))
        {
          PickupObject(hit.transform.gameObject, item);
          //item.OnHandlePickupItem();

        }
        else if(hit.transform.gameObject.tag == "Lunchable")
        {
          hit.transform.gameObject.SendMessage("KillChicken", SendMessageOptions.DontRequireReceiver);
        }
      }
    }

    if (Input.GetKeyDown(KeyCode.Q))
    {

      GameObject objectToDrop = InventorySystem.current.Remove();
      if (objectToDrop != null) {
        DropObject(objectToDrop);
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

  void PickupObject (GameObject pickobj, ItemObject item)
  {
    if (pickobj.GetComponent<Rigidbody>())
    {
      Rigidbody objRig = pickobj.GetComponent<Rigidbody>();
      Collider objCollide = pickobj.GetComponent<Collider>();
      objCollide.enabled = false;
      objRig.useGravity = false;
      objRig.drag = 20;
      objRig.transform.parent = holdParent;
      heldobj = pickobj;
      StartCoroutine(timedPickup(0.25f, item));
      //item.OnHandlePickupItem();
      //heldobj.SetActive(false);
    }
  }

  void DropObject(GameObject objectToDrop)//chnage heldobj to a paramter that determines the object being thrown away
  {
    Rigidbody heldRig = objectToDrop.GetComponent<Rigidbody>();
    Collider heldCollide = objectToDrop.GetComponent<Collider>();
    heldCollide.enabled = true;
    heldRig.useGravity = true;
    heldRig.drag = 1;
    objectToDrop.transform.parent= null;
    heldobj = null;
  }

  IEnumerator timedPickup(float time, ItemObject item) {
    yield return new WaitForSeconds(time);
    item.OnHandlePickupItem();
  }
}
