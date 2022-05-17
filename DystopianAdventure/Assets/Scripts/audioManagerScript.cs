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
    public GameObject moon;

    bool inDarkForest = false;
    bool day = true;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_AudioSource = GetComponent<AudioSource>();
        //Output the current clip's length
    }

    void Update()
    {
        //Switch background music when you step into dark forest
        if (mainPlayer.transform.position.x < -129f && mainPlayer.transform.position.x > -741f && mainPlayer.transform.position.z < 1780f && mainPlayer.transform.position.z > 1061f)
        {
            if(!inDarkForest) {
                SwitchAudio(darkForest);
                inDarkForest = true;
            }
        }
        else
        // if not in dark forest
        {
            if(inDarkForest) {
                inDarkForest = false;
                // if its sun is above a certain y value in the sky play day audio clip
                // else its night play night audio clip
                if(sun.transform.position.y > 0) {
                    // play sun clip
                    SwitchAudio(dayLoop);
                } else {
                    // play night clip
                    SwitchAudio(nightLoop);
                }

            }
            else {

                if(day)
                {
                    if(sun.transform.position.y < 0)
                    {
                        day = false;
                        // play night clip
                        SwitchAudio(nightLoop);
                    }
                }
                else
                {
                    if(sun.transform.position.y > 0)
                    {
                    day = true;
                    // play sun clip
                    SwitchAudio(dayLoop);
                    }
                }

            }

        }
    }

    void SwitchAudio(AudioClip backgroundSong)
    {
        /*
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
        */
    }
}
