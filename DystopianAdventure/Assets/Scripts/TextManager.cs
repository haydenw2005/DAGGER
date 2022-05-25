using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text upTxt;
    public Text downTxt;
    private bool isHovered;
    private bool clickSelect;
    private bool eSelect;
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
        if(clickSelect)
        {
          upTxt.text = "Press F to Pick Up";
          clickSelect = false;
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
      if(select.tag == "Selectable")
      {
        isHovered = true;
        clickSelect = true;
      }
    }

    void currentHeld(GameObject heldItem)
    {
      heldObj = heldItem;
    }
}
