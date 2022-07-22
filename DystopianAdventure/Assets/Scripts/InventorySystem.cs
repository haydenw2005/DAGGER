using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;
    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory;
    public List<SlotScript> slots;
    private static int totalSlots = 5;
    private int currentSlot = 2;

    private void Awake() {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>(); 
        emptyInventory();
        changeSlots(1);
        currentSlot = 1;
        for (int i = 0; i < totalSlots; i++) {
            inventory.Add(null);
        }
    }
    private void Update() {
        if(Input.anyKeyDown) { // && Input.inputString != currentSlot.ToString()]
            switch (Input.inputString) {
                case "1":
                    changeSlots(1);
                    currentSlot = 1;
                    break;
                case "2":
                    changeSlots(2);
                    currentSlot = 2;
                    break;
                case "3":
                    changeSlots(3);
                    currentSlot = 3;
                    break;
                case "4":
                    changeSlots(4);
                    currentSlot = 4;
                    break;
                case "5":
                    changeSlots(5);
                    currentSlot = 5;
                    break;
            }
        }

        if (slots[currentSlot-1].itemsInSlot.Count >= 1) {
            slots[currentSlot-1].itemsInSlot[0].TryGetComponent<ItemObject>(out ItemObject item);
            item.enableObject();
        }
    }

    public int getCurrentSlot() {
        return currentSlot;
    }

    private void changeSlots(int lastSlot) {
        slots[currentSlot-1].m_label.color = new Color32(255, 255, 255, 255);
        slots[currentSlot-1].m_border.color = new Color32(255, 255, 255, 255);
        slots[lastSlot-1].m_label.color = new Color32(15, 98, 230, 255);
        slots[lastSlot-1].m_border.color = new Color32(15, 98, 230, 255);
        if (slots[currentSlot-1].itemsInSlot.Count >= 1) {
            slots[currentSlot-1].itemsInSlot[0].TryGetComponent<ItemObject>(out ItemObject item);
            item.disableObject();
        }
    }



    public void UpdateInventoryUI() {
        for (int i = 0; i < totalSlots; i++) {

            try {
                slots[i].Set(inventory[i]); 
                //inventory[i].data.prefab.GetComponent<Renderer>().enabled = false;
            }
            catch {
                slots[i].Empty(i);
            }
        }
    }

    public void emptyInventory() {
        for (int i = 0; i < totalSlots; i++) {
                slots[i].Empty(i);
        }
    }
    /*public ItemObject GetObject(InventoryItemData referenceData) {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            return value;
        }
        return null;
    }*/
    
    public void Add(InventoryItemData referenceData, GameObject gameObject) {
        InventoryItem newItem = new InventoryItem(referenceData);
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.AddToStack();
            slots[inventory.IndexOf(value)].addToSlot(gameObject);
        }
        else {
            for (int i = 0; i < totalSlots; i++) {
                if (inventory[i] == null) {
                    inventory[i] = newItem;
                    break;
                }
            }
            m_itemDictionary.Add(referenceData, newItem);
            slots[inventory.IndexOf(newItem)].addToSlot(gameObject);
        }
    }

    public GameObject Remove() {
        if (slots[currentSlot-1].itemsInSlot.Count > 0) {
            GameObject objectToRemove = slots[currentSlot-1].itemsInSlot[0];
            InventoryItemData referenceData = inventory[currentSlot-1].data;
            if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
                value.RemoveFromStack();

                if (value.stackSize == 0) {
                    inventory[inventory.IndexOf(value)] = null;
                    m_itemDictionary.Remove(referenceData);
                }
                slots[currentSlot-1].itemsInSlot.RemoveAt(0);
                UpdateInventoryUI();
                return objectToRemove;
            }
        }
        return null;
    }

    public bool isFull(ItemObject currentObject) {
        for (int i = 0; i < 5; i++) {
            try {
                slots[i].itemsInSlot[0].TryGetComponent<ItemObject>(out ItemObject item);
                if (item.referenceItem.id == currentObject.referenceItem.id) {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
        return true;
    }
}