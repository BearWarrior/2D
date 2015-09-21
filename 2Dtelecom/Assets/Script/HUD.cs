using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private GameObject joueur;

    //Rect
    private Rect rectPointDeVie;


	// Use this for initialization
	void Start ()
    {
        joueur = GameObject.FindWithTag("Player");
        rectPointDeVie = new Rect(10, 10, 200, 30);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    {
        GUI.Box(rectPointDeVie, "Point de vie : " + joueur.GetComponent<Joueur>().getPointDeVie());
    }
}

