using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SlotScript : MonoBehaviour
{
    public List<GameObject> itemsInSlot;

    [SerializeField]
    public Image m_border;

    [SerializeField]
    public Image m_icon;
    
    [SerializeField]
    public TextMeshProUGUI m_label;

    [SerializeField]
    public GameObject m_stackObj;

    [SerializeField]
    public TextMeshProUGUI m_stackLabel;

    public void Set(InventoryItem item) {
        m_stackObj.SetActive(true);
        changeColor(255f);
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        m_stackLabel.text = item.stackSize.ToString();
    }
    
    public void Empty(int i) {
        m_stackObj.SetActive(false);
        m_icon.sprite = null;
        changeColor(0f);
        m_label.text = "Slot " + (i+1);
        
    }

    private void changeColor(float newAlpha) {
        var tempColor = m_icon.color;
        tempColor.a = newAlpha;
        m_icon.color = tempColor;
    }

   /* public void setIsCurrentStatus(bool isTrue) {
        isCurrent = isTrue;
    }
    */
    public void addToSlot(GameObject newObject) {
        itemsInSlot.Add(newObject);
    } 
}
