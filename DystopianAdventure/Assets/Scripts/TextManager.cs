using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text upTxt;
    public Text downTxt;
    private bool isHovered;
    private bool fSelect;
    private bool fKill;
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
          upTxt.text = "Press F to Pick Up";
          fSelect = false;
        }
        else if(fKill)
        {
          upTxt.text = "Press F to kill";
          fKill = false;
        }
        isHovered = false;
      }
      else
      {
        upTxt.text = "";
      }
      if(heldObj != null)
      {
        if(heldObj.name == "BikeCrystal")
        {
          downTxt.text =  "Bring to Bike and Press E to Enter";
        }
        else if(heldObj.name == "TeleCrystal")
        {
          downTxt.text = "Bring to Telepad and Press E to Activate";
        }
        else if(heldObj.name == "SausageSlice(Clone)" || heldObj.name == "Ham(Clone)"
        || heldObj.name == "Steak(Clone)" || heldObj.name == "WholeBirdRaw(Clone)")
        {
          downTxt.text = "Press E to Eat";
        }
        else
        {
          downTxt.text = "Press Q to Drop";
        }
        heldObj = null;
      }
      else
      {
        downTxt.text = "";
      }
    }

    void canPickUp(GameObject select)
    {
      isHovered = true;
      if(select.tag == "Selectable")
      {
        fSelect = true;
      }
      else if(select.tag == "Lunchable")
      {
        fKill = true;
      }
    }

    void currentHeld(GameObject heldItem)
    {
      heldObj = heldItem;
    }
}
