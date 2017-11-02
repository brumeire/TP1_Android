using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class GyroscopeScript : MonoBehaviour 
{

	[SerializeField]
	private float rotationSpeed = 0.2f;
	public Text text;

	void Start() 
	{
		Input.gyro.enabled = true;
	}

	void Update()
	{
		transform.rotation = ConvertRot(Input.gyro.attitude);
		text.text = Input.gyro.attitude.ToString();
	}

	private Quaternion ConvertRot(Quaternion input)
	{
		return new Quaternion(-input.y, input.x, input.z, -input.w);
	}	
	#region old

// public float speed = 0.2f;
	// public Text text;

	// void Update()
	// {
	// 	Vector3 input = Input.acceleration;
	// 	transform.Rotate(input*speed*Time.deltaTime);
	// 	text.text = Input.acceleration.ToString();
		
	// }
/*
	X = gauche-droite : gauche -1 - droite 1
	
	Z = face vers le haut : haut -1 - bas -1

 */


	/*
	[SerializeField]
	private float rotationSpeed =0.2f;
	public Text text;

	void Start()
	{
		Input.gyro.enabled = true;
	}

	void Update()
	{
		transform.rotation = ConvertRot(Input.gyro.attitude);
		text.text = Input.gyro.attitude.ToString();
	}

	private Quaternion ConvertRot(Quaternion input)
	{
		return new Quaternion(-input.y, input.x, input.z, -input.w);
	}

/*
	private Quaternion GetRotFix()
	{
    if (Screen.orientation == ScreenOrientation.Portrait)
        return Quaternion.identity;
    if (Screen.orientation == ScreenOrientation.LandscapeLeft
    || Screen.orientation == ScreenOrientation.Landscape)
        return Quaternion.Euler(0, 0, -90);
    if (Screen.orientation == ScreenOrientation.LandscapeRight)
        return Quaternion.Euler(0, 0, 90);
    if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        return Quaternion.Euler(0, 0, 180);
    return Quaternion.identity;
	}
*/
#endregion
}
