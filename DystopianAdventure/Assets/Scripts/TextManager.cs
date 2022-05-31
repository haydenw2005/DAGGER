using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI upTxt;
    public TextMeshProUGUI downTxt;
    private bool isHovered;
    private bool clickSelect;
    private bool eSelect;
    private bool clickKill;
    private bool clickActivate;
    private bool clickEat;
    private GameObject heldObj = null;

    void Start()
    {
      isHovered = false;
      upTxt.text = "";
      downTxt.text = "";
    }

    void Update()
    {
      if(isHovered)
      {
        if(fSelect)
        {
          downTxt.text = "Press F to Pick Up";
          clickSelect = false;
        }
        else if (clickKill) {
          downTxt.text = "Press F to Kill";
          clickKill = false;
        }
        else if (clickActivate) {
          if (heldObj != null && (heldObj.name == "BikeCrystal" || heldObj.name == "Hammer" || heldObj.name == "TeleCrystal")) {
            downTxt.text = "Press E to Activate";
            heldObj = null;
          } else {
            downTxt.text = "Item Required";
          }
          clickActivate = false;
        }
        isHovered = false;
      }
      else
      {
        downTxt.text = "";
      }
      if(heldObj != null)
      {
        if(heldObj.name == "BikeCrystal")
        {
          upTxt.text =  "Tip: Bring to Hover Bike";
        }
        else if(heldObj.name == "TeleCrystal")
        {
          upTxt.text = "Tip: Bring to Telepad";
        }
        else if(heldObj.name == "Hammer")
        {
          upTxt.text = "Tip: Bring to Radar";
        }
        else if(heldObj.tag == "Meat")
        {
          upTxt.text = "Tip: E to Consume";
        }
        else if(heldObj.name == "SausageSlice(Clone)" || heldObj.name == "Ham(Clone)"
        || heldObj.name == "Steak(Clone)" || heldObj.name == "WholeBirdRaw(Clone)")
        {
          downTxt.text = "Press E to Eat";
        }
        else
        {
          upTxt.text = "Tip: Press Q to Drop";
        }
        heldObj = null;
      }
      else
      {
        upTxt.text = "";
      }
    }

    void canPickUp(GameObject select)
    {
      if(select.tag == "Selectable" || select.tag == "Meat")
      {
        fSelect = true;
      }
      else if(select.tag == "Lunchable")
      {
        fKill = true;
      }
      else if(select.tag == "Lunchable") {
        isHovered = true;
        clickKill = true;
      }
      else if(select.tag == "Activation") {
        isHovered = true;
        clickActivate = true;
      }
    }

    void currentHeld(GameObject heldItem)
    {
      heldObj = heldItem;
    }
}
