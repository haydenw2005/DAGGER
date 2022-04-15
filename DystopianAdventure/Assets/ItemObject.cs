using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem() {
        InventorySystem.current.Add(referenceItem);
        InventorySystem.current.UpdateInventoryUI();
        //call UI update
        Destroy(gameObject);
    }

    public void deleteItems() {
        InventorySystem.current.emptyInventory();
    }
}
