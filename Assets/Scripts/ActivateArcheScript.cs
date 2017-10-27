using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArcheScript : MonoBehaviour 
{
	private GameObject[] pieceOfArche;


	void OnTriggerStay(Collider other)
	{			
		if (other.gameObject.tag == "Trigger") 
		{
			RaycastHit hit;
			Debug.DrawRay (transform.position, transform.forward, Color.red, 1f);

			if (Physics.Raycast (transform.position, transform.forward, out hit))
			{
				if (hit.transform.tag == "Arche") 
				{
					pieceOfArche = GameObject.FindGameObjectsWithTag ("Arche");
					foreach (GameObject piece in pieceOfArche) 
					{
						piece.GetComponent<Renderer> ().material.color = Color.blue;
					}
				}
			}
		}
	}
}
