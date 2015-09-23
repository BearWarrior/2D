


using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private Rect rectBox;


    //Variables lies au butt 1
    private Rect rectButt1; //Rectangle
    private int butt1State = 0; // Etat de l'ecriture du striong allant dfe 1 a dureeAffich
    private string butt1Text = ""; // Variable stockant le texte a afficher, modifier par la fct animString
    private string butt1TextToolTipFinal = "Lancez une partie !"; // Texte du Tooltip
    private string butt1TextButton = "Lancez une partie !"; // Texte du Button




    private char lastChar; // variable pour sotcker le dernier charactere aleatoire, afin de ne pas changer trop souvent
    private int dureeAffich; // Int init dans le start (duree de l'affichage)

    private GUISkin skin1; // GUI skin
    //Pos de la souris
    private Vector2 mousePos; // Stock la pos de la mouse





    // Taille de l'image de fond
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

        // int pour choisir le temps necessaire a l'affichage
        dureeAffich = 150;
    }

    // Update is called once per frame
    void Update()
    {
        // recupere la pos de la souris
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);


        // Button1 : if souris dessus, afficher tooltip; snon, pas afficher, et remettre compteur a 0
        if (mousePos.x > rectButt1.x && mousePos.x < (rectButt1.x + rectButt1.width) && mousePos.y > rectButt1.y && mousePos.y < (rectButt1.y + rectButt1.height))
        {
            if (butt1State < dureeAffich)
            {
                butt1State++;
                butt1Text = animString(butt1TextToolTipFinal, butt1State);
            }
        }
        else
        {
            butt1State = 0;
            butt1Text = butt1TextToolTipFinal;

        }
    }


    void OnGUI()
    {
        GUI.skin = skin1;
        // Box prionc + ecran
        GUI.Box(rectBox, "MENU");

        // Genre le button, le tooltip est con,fig par le label situe juste apres
        GUI.Button(rectButt1, new GUIContent("> Jouer", butt1Text));
        GUI.Label(new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y + 20, 200, 40), GUI.tooltip);
    }


    private string animString(string toDisplay, int currentState)
    {
        int tailleTotale = toDisplay.Length;
        string stringRetour = "";
        int k = 0;
        for (int i = 0; i < currentState;  i += (dureeAffich / tailleTotale))
        {
            Debug.Log(" i = " + i.ToString() + "currentstate = " + currentState.ToString());
            stringRetour += toDisplay[k];
            k++;
        }
        int tailleAvantRand = stringRetour.Length;
        Debug.Log(butt1State.ToString());
        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (currentState % 6 == 0)
                lastChar = (char)Random.Range(97, 124);

            stringRetour += lastChar;
            stringRetour += '█';
        }
        return stringRetour;
    }


}



