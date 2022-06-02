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
    private bool clickRadar;
    private bool clickBike;
    private bool clickTele;
    private GameObject heldObj = null;
    private bool currentIsActive = false;


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
          downTxt.text = "Press F to Pick Up";
          clickSelect = false;
        }
        else if (clickKill) {
          downTxt.text = "Press F to Kill";
          clickKill = false;
        }
        else if (clickRadar) {
          if (currentIsActive == false) {
            downTxt.text = "Item Required";
          }
          clickRadar = false;
          currentIsActive = false;
        }
        else if (clickBike) {
          if (currentIsActive != true) {
            downTxt.text = "Item Required";
          } else {
            downTxt.text = "Press E to enter";
          }
          clickBike = false;
          currentIsActive = false;
        }
        else if (clickTele) {
          if (currentIsActive != true) {
            downTxt.text = "Item Required";
          } else {
            downTxt.text = "Touch the pad...";
          }
          clickTele = false;
          currentIsActive = false;
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
      //Debug.Log(select.tag);
      //Debug.Log(select.name);
      if(select.tag == "Selectable" || select.tag == "Meat")
      {
        isHovered = true;
        clickSelect = true;
      }
      else if(select.tag == "Lunchable") {
        isHovered = true;
        clickKill = true;
      }
      else if(select.name == "Radar") {
        isHovered = true;
        clickRadar = true;     
        currentIsActive = select.GetComponent<RadarScript>().isActivated; 
      }
      else if(select.name == "HoverBike") {
        isHovered = true;
        clickBike = true;
        currentIsActive = select.GetComponent<HoverCarControl>().isActivated;
      }
      else if(select.name == "TeleportPad") {
        isHovered = true;
        clickTele = true;
        currentIsActive = select.GetComponent<TeleportScript>().isActivated;
      }/*
      else if(select.tag == "Activation") {
        isHovered = true;
        clickActivate = true;
        //current = select;
      } */
    }

    void currentHeld(GameObject heldItem)
    {
      heldObj = heldItem;
    }
}
