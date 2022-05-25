using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
  public Transform playerAxis;
  public float pickUpRange=5;
  public float moveForce = 250;
  public Transform holdParent;
  public GameObject textMaker;
  private GameObject heldobj;
  public InventorySystem inventory;
  // Update is called once per frame

  void Update()
  {

    RaycastHit select;
    if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out select, pickUpRange))
    {
      select.collider.SendMessage("HitByRay", SendMessageOptions.DontRequireReceiver);
      if(select.collider.tag == "Lunchable" || select.collider.tag == "canPickUp" || select.collider.tag == "Selectable")
      {
        textMaker.SendMessage("canPickUp", select.transform.gameObject, SendMessageOptions.DontRequireReceiver);
      }
    }

    if (Input.GetKeyDown("f"))
    {
      RaycastHit hit;
      if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hit, pickUpRange))
      {
        if(hit.transform.gameObject.tag == "Selectable" && hit.transform.gameObject.TryGetComponent<ItemObject>(out ItemObject item) && inventory.isFull(item) == false)
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
      Debug.Log(pickobj);
      Debug.Log(item);
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
