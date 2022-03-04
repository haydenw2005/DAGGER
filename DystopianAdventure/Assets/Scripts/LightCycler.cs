using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycler : MonoBehaviour
{
	public float rotateSpeed;

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(Vector3.zero,Vector3.right,rotateSpeed*Time.deltaTime);
		transform.LookAt(Vector3.zero);
	}
}
