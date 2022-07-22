using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailCollider : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Terrain" || other.gameObject.name == "Terrain2")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

}
