using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour 
{

	void Start () 
	{
		
	}
	

	void Update () 
	{
		transform.Rotate (100f * Time.deltaTime, 80f * Time.deltaTime, 75f * Time.deltaTime);
	}
}
