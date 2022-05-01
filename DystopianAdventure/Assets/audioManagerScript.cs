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
    public AudioClip m_AudioClip2;
    public GameObject mainPlayer;

    bool inDarkForest = false;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_AudioSource = GetComponent<AudioSource>();
        //Set the original AudioClip as this clip
        m_AudioClip = m_AudioSource.clip;
        //Output the current clip's length
        Debug.Log("Audio clip length : " + m_AudioSource.clip.length);
    }

    void Update()
    {
        Debug.Log(mainPlayer.transform.position.x + " " + mainPlayer.transform.position.z);
        Debug.Log(inDarkForest);
        //Switch background music when you step into dark forest
        if (mainPlayer.transform.position.x < -129f && mainPlayer.transform.position.x > -741f && mainPlayer.transform.position.z < 1780f && mainPlayer.transform.position.z > 1061f)
        {
            if(!inDarkForest) {
                SwitchAudio();
                inDarkForest = true;
            }     
        }
        else 
        {
            if(inDarkForest) {
                inDarkForest = false;
                Debug.Log("not in dark forest");
                SwitchAudio();
            }

        }
    }

    void SwitchAudio()
    {
        //If the current Audio clip is the original Audio clip, switch to the second clip
        if (m_AudioSource.clip == m_AudioClip)
        {
            //Switch to the second clip
            m_AudioSource.clip = m_AudioClip2;
            //Play the second clip
            m_AudioSource.Play();
        }
        //Otherwise, if the current Audio clip is the second clip, switch back
        else if (m_AudioSource.clip == m_AudioClip2)
        {
            //Switch back to the original Audio clip
            m_AudioSource.clip = m_AudioClip;
            //Play the original clip
            m_AudioSource.Play();
        }
        //Ouput the length of the current Audio clip
        Debug.Log("Audio clip length : " + m_AudioSource.clip.length);
    }
}
