using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArcheScript : MonoBehaviour 
{
	private GameObject[] pieceOfArche;
	public GameObject[] pieceOfArcheFusionnee;
	private GameObject archeFusionnee;
	private GameObject portail;

	void Start()
	{
		archeFusionnee = GameObject.Find ("Arche_Fusionnee");
		portail = GameObject.Find ("Portail");
		archeFusionnee.SetActive (false);
		portail.GetComponent<Transform> ().localScale = Vector3.zero;
		portail.SetActive (false);
	}
		
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
						piece.SetActive (false);
					}
					archeFusionnee.SetActive (true);
					foreach (GameObject go in pieceOfArcheFusionnee) 
					{
						go.SetActive (true);
					}
					new WaitForSeconds (1f);
					portail.SetActive (true);

					StartCoroutine ("LaunchPortal");
				}
			}
		}
	}

	public IEnumerator LaunchPortal()
	{
		while (portail.GetComponent<Transform> ().localScale.x < 38f) 
		{
			portail.GetComponent<Transform> ().localScale += new Vector3(3.8f,1f,3.2f) * Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}
}
