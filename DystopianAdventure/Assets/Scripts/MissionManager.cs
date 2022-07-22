using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
  public TextMeshProUGUI missionTxt;
  public TextMeshProUGUI guideHintTxt;
  public GameObject border;
  public Image crosshair;
  public GameObject message;
  public GameObject pauseMenu;
  private bool isActive = false;
  // Start is called before the first frame update
  void Start()
  {
    border.SetActive(false);
    missionTxt.text = "Do you read ~OVER~ .... bzzt ... System... Damage... Communication offline.. BZZZZT... Find hammer in crash site ... Antenna on Pod... Stand by for future... Zzztzzz...";
  }

  void Update() {
    if(Input.GetKeyDown(KeyCode.Tab)) {
      if(isActive) {
        DisableGuide();
      } else if(pauseMenu.active == false) { //if not open
        EnableGuide();
      }
    }
  }

  public void DisableGuide() {
    guideHintTxt.text = "Tab to enter mission control";
    isActive = false;
    border.SetActive(false);
    message.SetActive(false);
    crosshair.enabled = true;
  }

  public void EnableGuide() {
    guideHintTxt.text = "Tab to exit mission control";
    isActive = true;
    border.SetActive(true);
    crosshair.enabled = false;
  }

//uses SendMessage system, when a task is completed, a message is sent to this script that advances the UI
  void MissionOne()
  {
    missionTxt.fontSize = 16;
    message.SetActive(true);
    missionTxt.text = "Great job soldier, the communication is now online. It seems your navigation console was damaged in flight, leaving you stranded on the uncharted planet B6-77P. Luckily, mission control has you covered, and we have devised a plan for your escape. The first step of this plan is to find a hover bike to cross the river which seperates you from our access point. Our radar detects that one is hidden in a disguised bush southwest of the pod. ";
  }

  void MissionTwo()
  {
    missionTxt.fontSize = 19;
    message.SetActive(true);

    missionTxt.text = "Excellent work, soldier. You found the hover bike. However, there is one issue: the bike has no power. Fortunately, there appears to be an Onealium outcrop just northwest of the bike; one crystal should do the trick and get it working again.";
  }

  void MissionThree()
  {
    missionTxt.fontSize = 23;
    message.SetActive(true);
    missionTxt.text = "Nice job. Now go back to the bike and activate it.";
  }

  void MissionFour()
  {
    missionTxt.fontSize = 18;
    message.SetActive(true);
    missionTxt.text = "The bike is now running smoothly, so we can move on to the next step of our plan. Across the river there is teleporter that can take you home. In order to power it, you will need a shard of Telenium which lays in a cave. This cave can be found southwest from the original location of the bike, deep within a forest...";
  }

  void MissionFive()
  {
    missionTxt.fontSize = 19;
    message.SetActive(true);
    missionTxt.text = "Now that you have the crystal, you are ready to go home. Energy signals from the teleporter are off the charts, so be careful. It appears that the last time it was used it caused massive destruction. The teleporter can be found east from the telenium cave.";
  }
  void MissionSix()
  {
    missionTxt.fontSize = 22;
    message.SetActive(true);
    missionTxt.text = "Was it... all a dream?";
  }
}
