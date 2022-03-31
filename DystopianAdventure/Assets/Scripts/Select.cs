using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    private Renderer selectRender;
    private bool rayHit;

    // Start is called before the first frame update
    void Start()
    {
      rayHit = false;
      selectRender = GetComponent<Renderer>();
    }

    void Update()
    {
      if(rayHit)
      {
        selectRender.material.color = Color.blue;
        rayHit = false;
      }
      else
      {
        selectRender.material.color = Color.white;
      }
    }

    void HitByRay()
    {
      rayHit = true;
    }
}
