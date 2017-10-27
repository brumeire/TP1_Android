using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClicScript : MonoBehaviour
{
	public float delai;

	void Update () 
	{
		for (int i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began) 
			{
				if (Input.GetTouch(i).tapCount == 2)
				{
					StartCoroutine (MoveCameraForward());
				}
			}
		}
		/*
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			StartCoroutine (MoveCameraForward());
		}*/
	}

	public IEnumerator MoveCameraForward()
	{
		for (int i = 0; i < delai; i++) 
		{
			transform.Translate (Vector3.forward);
			yield return new WaitForFixedUpdate();
		}
	}
}
