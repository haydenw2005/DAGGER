using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTP : MonoBehaviour
{
    public Transform Spawn;
    public GameObject Player;

    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonPlayer")
        {
            Debug.Log("whoosh");
            //Player.Rigidbody.position = Spawn.Rigidbody.position;
            Player.transform.position = Spawn;
        }
    }
    */

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");
        if(other.gameObject.name == "RiverWater")
        {
            Debug.Log("whoosh");
            //Player.Rigidbody.position = Spawn.Rigidbody.position;
            //transform.localPosition = Vector3.MoveTowards (transform.localPosition, Spawn.transform.position, Time.deltaTime * 400f)
            //this.GetComponent<Rigidbody>().AddForce(Spawn.transform.position * 400f);
            //this.GetComponent<Rigidbody>().MovePosition(transform.position + Spawn.transform.position * Time.deltaTime * 400f);
        }
    }
    
}
