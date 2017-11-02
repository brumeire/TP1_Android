using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominantColorScript : MonoBehaviour {

    private bool hasCamAuthorisation = false;

    WebCamTexture webcamTexture;

    public Color averageColor = new Color();


    public float timerAverageColorCheck = 1;

    private float actualTimer;


    public Renderer[] objectsColorChange;


    // Use this for initialization
    void Start ()
    {
        //StartCoroutine(CamRequest());
        actualTimer = 0;
       
        webcamTexture = new WebCamTexture();
        webcamTexture.Play();


    }
	
	// Update is called once per frame
	void Update ()
    {
		if (!hasCamAuthorisation)
        {
            actualTimer += Time.deltaTime;

            if (actualTimer > timerAverageColorCheck)
            {
                actualTimer -= timerAverageColorCheck;
                averageColor = GetAverageColor();

                foreach(Renderer rend in objectsColorChange)
                {
                    rend.material.color = averageColor;
                    //rend.material.mainTexture = webcamTexture;
                }
            }
            
        }
	}


    /// <summary>
    /// Demande l'authorisation d'utiliser la caméra
    /// </summary>
    /// <returns></returns>
    IEnumerator CamRequest()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            yield return StartCamRecord(webcamTexture);
            hasCamAuthorisation = true;
            
        }

    }


    /// <summary>
    /// Cette fonction permet de lancer le record de ce que voit la caméra sur une texture
    /// </summary>
    /// 
    /// <param name="texture">
    /// La texture sur laquelle enregistrer l'input caméra
    /// </param>
    private int StartCamRecord(WebCamTexture texture)
    {
        texture = new WebCamTexture();
        //Renderer renderer = GetComponent<Renderer>();
        //renderer.material.mainTexture = webcamTexture;
        texture.Play();
        return 0;
    }


    /// <summary>
    /// Fonction permettant de prendre une snapshot de ce que voit la caméra et de déterminer la moyenne des couleurs présentes
    /// </summary>
    /// 
    /// <returns>
    /// La couleur moyenne de ce que voit la caméra
    /// </returns>
    private Color GetAverageColor()
    {
        webcamTexture.Play();
        Color[] colors = webcamTexture.GetPixels();

        Color average = new Color();

        foreach (Color color in colors)
        {
            average += color;
        }

        average /= colors.Length;

        return average;
    }
}
