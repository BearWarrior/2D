using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Personnage : MonoBehaviour
{
    protected string nom;
    protected float pointDeVie;
    protected float pointDeVieMax;

    protected float pointDeMana;
    protected float pointDeManaMax;
    //private float endurance;


    //Inventaire du personnage
    protected List<Objet> inventaire;
   // protected List<ObjetDeQuete> inventaireDeQuete;


    // Use this for initialization
    void Start ()
    {

	}

	
	// Update is called once per frame
	void Update ()
    {
	
	}


    //Fonction appelée lors d'une prise de dégats
    public void Hit(float damage)
    {
        pointDeVie -= damage;
        if(pointDeVie <= 0)
        {
            Die();
        }
    }


    //Fonction appelée lors de l'utilisation d'un consommable rendant des points de vie
    //Si le soin a fonctionné (il n'avait pas toute sa vie) alors on renvoit true, sinon (ça sert à rien de soin) on renvoie false
    /* public bool Soigner(float soin)
     {
         if(pointDeVie == pointDeVieMax)
         {
             return false;
         }
         else
         {
             pointDeVie += soin;
             if (pointDeVie > pointDeVieMax)
             {
                 pointDeVie = pointDeVieMax;
             }
             return true;
         }

     }*/

    protected bool UtiliserConsommable(Consommable c)
    {
        bool retour;
        retour = false;
        //Si on a réussi a soigner on renvoie true, sinon false
        //Au retour, si true : on détruit l'objet, si false : on le laisse
        if (pointDeVie != pointDeVieMax)
        {
            pointDeVie += c.getPointDeVie();
            if (pointDeVie > pointDeVieMax)
            {
                pointDeVie = pointDeVieMax;
            }
            retour = true;
        }

        if (pointDeMana != pointDeManaMax)
        {
            pointDeMana += c.getPointDeMana();
            if (pointDeMana > pointDeManaMax)
            {
                pointDeMana = pointDeManaMax;
            }
            retour = true;
        }

        return retour;
    }


    //Fonction appelée lors de la mort du personnage
    public void Die()
    {

    }

    //Accesseur :  aka GetteurSetteur
    public float getPointDeVie() { return pointDeVie; }
    public string getNom() { return nom; }
}
