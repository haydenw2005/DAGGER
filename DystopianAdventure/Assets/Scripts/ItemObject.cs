using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    /*public ItemObject(InventoryItemData source) {
        referenceItem = source;
    }*/

    public void OnHandlePickupItem() {
        InventorySystem.current.Add(referenceItem, gameObject);
        InventorySystem.current.UpdateInventoryUI();
        disableObject();
    }

    public void deleteItems() {
        InventorySystem.current.emptyInventory();
    }

    public void enableObject() {
        gameObject.SetActive(true);
    }

    public void disableObject() {
        gameObject.SetActive(false);
    }
}
