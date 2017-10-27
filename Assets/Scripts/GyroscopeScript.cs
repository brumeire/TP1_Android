using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeScript : MonoBehaviour 
{
	void Update()
	{
		transform.rotation = Input.gyro.attitude;
	}
}
