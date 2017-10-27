using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    private Touch firstTouch;
    private Touch secondTouch;

    private Vector2 dist1;
    private Vector2 dist2;

    void Start () {
		
	}
	
	void Update () {
        firstTouch = Input.GetTouch(0);
        secondTouch = Input.GetTouch(1);
        if (CheckZoom())
            Camera.main.fieldOfView = Camera.main.fieldOfView + 10.0f;
	}

    private void CheckFingers()
    {
        Debug.Log(firstTouch);
        Debug.Log(secondTouch);
    }

    private Vector2 GetDistance (Vector2 firstPos, Vector2 secondPos)
    {
        Vector2 distance = secondPos - firstPos;
        return distance;
    }

    private bool CheckZoom()
    {
        dist1 = GetDistance(firstTouch.position, secondTouch.position);
        float timer = 1.0f;
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            dist2 = GetDistance(firstTouch.position, secondTouch.position);
            timer = 1.0f;
            if (dist1.magnitude < dist2.magnitude)
            {
                return true;
            }
        }
        return false;
    }
}
