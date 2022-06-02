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
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    public int numTurkey;
    public int numPig;
    public int numSheep;
    public int numCow;

    //generates each of the animals randomly between the bounds of the inputted x and z coordinates
    void Start()
    {
      for (int i = 0; i <= numTurkey; i++)
        {
          float randX = Random.Range(xMin,xMax);
          float randZ = Random.Range(zMin, zMax);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(turkey, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numPig; i++)
        {
          float randX = Random.Range(xMin,xMax);
          float randZ = Random.Range(zMin, zMax);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(pig, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numSheep; i++)
        {
          float randX = Random.Range(xMin,xMax);
          float randZ = Random.Range(zMin, zMax);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(sheep, randPosition, OgTransform.rotation);
        }
      for (int i = 0; i <= numCow; i++)
        {
          float randX = Random.Range(xMin,xMax);
          float randZ = Random.Range(zMin, zMax);
          Vector3 randPosition = new Vector3(randX, 70f, randZ);
          Instantiate(cow, randPosition, OgTransform.rotation);
        }
    }
}
