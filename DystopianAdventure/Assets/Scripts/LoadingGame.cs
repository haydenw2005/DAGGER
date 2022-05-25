using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadingGame : MonoBehaviour
{
    public CharacterController cc;
    public TextMeshProUGUI loadText;

    void Start()
    {
        Debug.Log("Start");
        //gameObject.active = false;
        StartCoroutine(ExecuteAfterTime(4));
        //cc.enabled = false;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(1);
        loadText.text = "Loading.";
        yield return new WaitForSeconds(1);
        loadText.text = "Loading..";
        yield return new WaitForSeconds(1);
        loadText.text = "Loading...";
        yield return new WaitForSeconds(1);

        gameObject.active = false;
        cc.enabled = true;
        // Code to execute after the delay
    }
}
