using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float duration;    //the max time of a walking session (set to ten)
    private Rigidbody rb;
    float elapsedTime   = 0f; //time since started walk
    float wait          = 0f; //wait this much time
    float waitTime      = 0f; //waited this much time

    float randomX;  //randomly go this X direction
    float randomZ;  //randomly go this Z direction

    bool move = true; //start moving

    void Start(){
        rb = GetComponent<RigidBody>();
        randomX =  Random.Range(-3,3);
        randomZ = Random.Range(-3,3);
    }

    void Update ()
    {
        //Debug.Log (elapsedTime);

        if (elapsedTime < duration && move) {
            //if its moving and didn't move too much
            Vector3 move = new Vector3(randomX,0,randomZ) * Time.deltaTime);
            rb.transform.Translate(move);
            elapsedTime += Time.deltaTime;

        } else if(wait == 0f) {
            //do not move and start waiting for random time
            move        = false;
            wait        = Random.Range (3, 8);
            waitTime    = 0f;
        }

        if (waitTime < wait && !move) {
            Debug.Log(wait);
            //you are waiting
            waitTime += Time.deltaTime;

        } else if(!move) {
            //you're done waiting
            Debug.Log("bye");
            move = true;
            elapsedTime = 0f;
            wait = 0f;
            randomX = Random.Range(-3,3);
            randomZ = Random.Range(-3,3);
        }
    }

}