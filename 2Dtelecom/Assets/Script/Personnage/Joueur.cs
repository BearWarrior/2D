using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Joueur : Personnage
{

	// Use this for initialization
	void Start ()
    {
        pointDeVieMax = 10;
        pointDeVie = pointDeVieMax - 5;

        

        inventaire = new List<Objet>();

        Ration res = new Ration();
        inventaire.Add(res);
    }
	

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.P))
        {
            if(inventaire[0] is Consommable)
            {
                Debug.Log("consommable");
                if(UtiliserConsommable((inventaire[0] as Consommable)))
                {
                    inventaire.RemoveAt(0);
                }
            }
            else
            {
                Debug.Log("pas consommable");
            }
        }
	}
}
