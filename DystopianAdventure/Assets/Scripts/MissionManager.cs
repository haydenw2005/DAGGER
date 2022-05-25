using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
  public Text txt;
  // Start is called before the first frame update
  void Start()
  {
    txt.text = "You've crash landed onto Earth!";
  }

  // Update is called once per frame
  void Update()
  {

  }

  void MissionOne()
  {
    txt.text = "Congrats! Mission 1 complete!";
  }

  void MissionTwo()
  {

  }

  void MissionThree()
  {
    txt.text = "Congrats! Mission 3 complete!";
  }
}
