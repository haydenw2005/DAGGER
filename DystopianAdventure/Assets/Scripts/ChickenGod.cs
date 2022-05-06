using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGod : MonoBehaviour
{
    public Transform OgTransform;
    public GameObject turkey;
    public GameObject pig;
    public GameObject sheep;
    public GameObject cow;
    public int numTurkey;
    public int numPig;
    public int numSheep;
    public int numCow;

    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i <= numTurkey; i++)
        {
          float randX = Random.Range(200,600);
          float randZ = Random.Range(400, 1000);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(turkey, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numPig; i++)
        {
          float randX = Random.Range(200,600);
          float randZ = Random.Range(400, 1000);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(pig, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numSheep; i++)
        {
          float randX = Random.Range(200,600);
          float randZ = Random.Range(400, 1000);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(sheep, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numCow; i++)
        {
          float randX = Random.Range(200,600);
          float randZ = Random.Range(400, 1000);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(cow, randPosition, OgTransform.rotation);
        }
    }
}
