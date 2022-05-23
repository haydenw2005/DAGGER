using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerScript : MonoBehaviour
{

    // credit to: https://docs.unity.cn/2017.3/Documentation/ScriptReference/AudioSource.Pause.html

   //Make sure your GameObject has an AudioSource component first
    AudioSource m_AudioSource;
    //Make sure to set an Audio Clip in the AudioSource component
    AudioClip m_AudioClip;
    //Make sure you set an AudioClip in the Inspector window
    public AudioClip dayLoop;
    public AudioClip nightLoop;
    public AudioClip darkForest;

    public GameObject mainPlayer;
    public GameObject sun;
    public GameObject hoverCamera;

    bool inDarkForest = false;
    bool day = true;
    public bool inCar;
    public GameObject hoverCar;
    private HoverCarControl anInstance;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_AudioSource = GetComponent<AudioSource>();
        anInstance = hoverCar.GetComponent<HoverCarControl>();
    }

    void Update()
    {
        // get instance of boolean that tells you if the player is in or out of hover car
        inCar = anInstance.getStatus();
        //Switch background music when player steps into dark forest
        if(inCar) 
        {
            // check if hover car camera  is in forest
            if (hoverCamera.transform.position.x < -101f && hoverCamera.transform.position.x > -997f && hoverCamera.transform.position.z < 1998f && hoverCamera.transform.position.z > 998.7f) 
            {
                // if hover car is in forest boundaries then check if they were already in forest and if they weren't then
                // switch audio to dark forest audio, this excessive checking is to prevent the song from being repeatedly played.
                if(!inDarkForest) {
                    SwitchAudio(darkForest);
                    Debug.Log("1");
                    inDarkForest = true;
                }    
            }
            else 
            {
                checkDay();
            }
        }
        else
        {
            // check if player is in forest
            if (mainPlayer.transform.position.x < -101f && mainPlayer.transform.position.x > -997f && mainPlayer.transform.position.z < 1998f && mainPlayer.transform.position.z > 998.7f)
            {   
                // if player is in forest boundaries then check if they were already in forest and if they weren't then
                // switch audio to dark forest audio, this excessive checking is to prevent the song from being repeatedly played.
                if(!inDarkForest) 
                {
                    SwitchAudio(darkForest);
                    inDarkForest = true;
                }  
            }
            else {
                checkDay();
            }
        }
    }

    void SwitchAudio(AudioClip backgroundSong)
    {
        m_AudioSource.clip = backgroundSong;
        m_AudioSource.Play();
    }

    public void checkDay() {
        if(inDarkForest) {
            inDarkForest = false;
            if(sun.transform.position.y > 0) {
                SwitchAudio(dayLoop);
            } else {
                SwitchAudio(nightLoop);
            }
        } else {
            if(day) 
            {
                if(sun.transform.position.y < 0) 
                {
                    day = false;
                    SwitchAudio(nightLoop);
                }
            } else {
                if(sun.transform.position.y > 0) {
                    day = true;
                    SwitchAudio(dayLoop);
                } 
            }
        }
    }
}
