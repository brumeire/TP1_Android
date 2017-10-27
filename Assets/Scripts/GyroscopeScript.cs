using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GyroscopeScript : MonoBehaviour 
{
	void Update()
	{
		transform.rotation = ConvertRot(Input.gyro.attitude)*GetRotFix();
	}

	private Quaternion ConvertRot(Quaternion input)
	{
		return new Quaternion(-input.y, input.x, input.z, -input.w);
	}

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

}
