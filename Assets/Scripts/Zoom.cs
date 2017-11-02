using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    private Touch firstTouch;
    private Touch secondTouch;

    private float previousDist = 0;

    private float dist1;
    private float dist2;

    public float speed = 5;

    void Start () {
		
	}
	
	void Update () {
        if (Input.touchCount >= 2)
        {
            firstTouch = Input.GetTouch(0);
            secondTouch = Input.GetTouch(1);



            float prevTouchDelta = ((firstTouch.position - firstTouch.deltaPosition) - (secondTouch.position - secondTouch.deltaPosition)).magnitude;

            float touchDelta = (firstTouch.position - secondTouch.position).magnitude;


            float deltaMagnitudeDiff = prevTouchDelta - touchDelta;

            Camera.main.fieldOfView += deltaMagnitudeDiff * Time.deltaTime * speed;

        }
	}

    private Vector2 GetDistance (Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 distance = secondPos - firstPos;
        return distance;
    }
}
