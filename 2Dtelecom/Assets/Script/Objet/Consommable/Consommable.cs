using UnityEngine;
using System.Collections;

public class Consommable : Objet
{
    protected float pointDeVie;
    protected float pointDeMana;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public float getPointDeVie()
    {
        return pointDeVie;
    }

    public float getPointDeMana()
    {
        return pointDeMana;
    }
    
}
