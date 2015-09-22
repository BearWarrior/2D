


using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private Rect rectBox;


    //Variables lies au butt 1
    private Rect rectButt1;
    private int butt1State = 0; // Etat de l'ecriture du striong allant dfe 1 a 10000
    private string butt1Text = "";
    private string butt1TextFinal = "Jouer";



    private char lastChar;
    private int dureeAffich;

    private GUISkin skin1;
    //Pos de la souris
    private Vector2 mousePos;

    // Taille de l'imlage de fond
    private Vector2 imageFond;
    // Use this for initialization
    void Start()
    {
        // init de la taille de ml'image
        imageFond = new Vector2(Screen.width, Screen.height);

        // rect De la fenetre principale, poura fficher l'image de fond et le texte principal
        rectBox = new Rect(Screen.width / 2 - imageFond.x / 2, Screen.height / 2 - imageFond.y / 2, imageFond.x, imageFond.y);

        //rect du 1er bouton
        rectButt1 = new Rect(50, Screen.height / 4, 200, 50);

        skin1 = Resources.Load("Menu/Menu") as GUISkin;

        dureeAffich = 150;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        if (mousePos.x > rectButt1.x && mousePos.x < (rectButt1.x + rectButt1.width) && mousePos.y > rectButt1.y && mousePos.y < (rectButt1.y + rectButt1.height))
        {
            if (butt1State < dureeAffich)
            {
                butt1State++;
                butt1Text = animString(butt1TextFinal, butt1State);
            }
        }
        else
        {
            butt1State = 0;
            butt1Text = butt1TextFinal;

        }
    }


    void OnGUI()
    {
        GUI.skin = skin1;
        GUI.Box(rectBox, "MENU");

        GUI.Button(rectButt1, new GUIContent(butt1Text, "This is the tooltip"));
        GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 40), GUI.tooltip);


        /*
        *Texte anime :
        */

    }


    private string animString(string toDisplay, int currentState)
    {
        int tailleTotale = toDisplay.Length;
        string stringRetour = "";
        int k = 0;
        for(int i = 0; i < currentState; i = i + (dureeAffich / tailleTotale))
        {
            //Debug.Log((i + (1000 / tailleTotale)).ToString());
            
            stringRetour += toDisplay[k];
            k++;
        }
        //stringRetour += '█';
        int tailleAvantRand = stringRetour.Length;
        Debug.Log(butt1State.ToString());
        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (currentState % 6 == 0)
            {
                //    for (int j = tailleAvantRand; j < tailleTotale; j++)
                //    {
                //        stringRetour += (char)Random.Range(97, 12);
                //    }
                lastChar = (char)Random.Range(97, 124);
                stringRetour += lastChar;

                stringRetour += '█';
            }
            else
            {
                stringRetour += lastChar;
                stringRetour += '█';
            }
        }

        return stringRetour;
    }

    
}

     

