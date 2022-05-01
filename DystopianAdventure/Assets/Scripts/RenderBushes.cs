using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBushes : MonoBehaviour
{
    public GameObject Bush;
    public GameObject BushPrefab;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = BushPrefab.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        for (int i = 0; i <= 100; i++)
        {
            Vector3 position = new Vector3(Random.Range(80f, 758f), 77f, Random.Range(213f, 1741f));
            Instantiate(BushPrefab, position, Bush.transform.rotation);
        }
        rb.isKinematic = true;
    }
}
