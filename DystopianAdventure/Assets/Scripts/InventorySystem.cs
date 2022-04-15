using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory;
    public List<SlotScript> slots;
    public static int totalSlots = 5;

    private void Awake() {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>(); 
        emptyInventory();
    }

    public void UpdateInventoryUI() {
        for (int i = 0; i < totalSlots; i++) {

            try {
                slots[i].Set(inventory[i]);
            }
            catch {
                //slots[i].Empty();
            }
        }
    }

    public void emptyInventory() {
        for (int i = 0; i < totalSlots; i++) {
                slots[i].Empty(i);
        }
    }
    /*public InventoryItem Get(InventoryItemData referenceData) {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            return value;
        }
        return null;
    }*/
    
    public void Add(InventoryItemData referenceData) {

        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.AddToStack();
        }
        else {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(InventoryItemData referenceData) {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.RemoveFromStack();

            if (value.stackSize == 0) {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }
}
