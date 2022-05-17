using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text txt;
    private bool isHovered;
    private bool isBox;

    void Start()
    {
      isHovered = false;
      txt.text = "";
    }

    void Update()
    {
      if(isHovered && isBox)
      {
        txt.text = "Press E to Pick Up";
        isHovered = false;
        isBox = false;
      }
      else if(isHovered)
      {
        txt.text = "Click to Kill";
        isHovered = false;
      }
      else
      {
        txt.text = "";
      }
    }

    void canPickUp(GameObject select)
    {
      if(select.tag == "Selectable")
      {
        isHovered = true;
        isBox = true;
      }
      else
      {
        isHovered = true;
      }
    }
}
