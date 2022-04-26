using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGod : MonoBehaviour
{
    public Transform OgTransform;
    public GameObject chicken;
    public GameObject sheep;
    public int numChick;
    public int numSheep;

    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i <= numChick; i++)
        {
          float randX = Random.Range(200,600);
          float randZ = Random.Range(400, 1000);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(chicken, randPosition, OgTransform.rotation);
        }
        for (int i = 0; i <= numSheep; i++)
          {
            float randX = Random.Range(200,600);
            float randZ = Random.Range(400, 1000);
            Vector3 randPosition = new Vector3(randX, 70f, randZ);
            Instantiate(sheep, randPosition, OgTransform.rotation);
          }
    }
}
