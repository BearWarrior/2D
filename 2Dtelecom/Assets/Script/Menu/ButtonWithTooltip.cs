using UnityEngine;
using System.Collections;

public class ButtonWithTooltip : MonoBehaviour {


    public Rect rectangle; //Rectangle
    private string textToDisplay; // Variable stockant le texte a afficher, modifier par la fct animString
    public string textTooltipFinal; // Texte du Tooltip
    public string textButton; // Texte du Button

    private char lastChar; // dernier charac stocke pour random pas trop rapide

    private int dureeAffichage;

    private int state; // Etat de l'ecriture du striong allant dfe 1 a dureeAffich

    private GUISkin skin1;

    public ButtonWithTooltip(string textButt, string textTooltip, Rect rectangleParam, int dureeAffichageParam = 1500)
    {
        textButton = textButt;
        textTooltipFinal = textTooltip;
        rectangle = rectangleParam;
        dureeAffichage = dureeAffichageParam;
        textToDisplay = "";
        state = 0;
    }

    public void init(string textButt, string textTooltip, Rect rectangleParam, int dureeAffichageParam = 1500)
    {
        textButton = textButt;
        textTooltipFinal = textTooltip;
        rectangle = rectangleParam;
        dureeAffichage = dureeAffichageParam;
        textToDisplay = "";
        state = 0;
        
    }


    // Use this for initialization
    void Start () {
        skin1 = Resources.Load("Menu/Menu") as GUISkin;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos;
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        if (mousePos.x > rectangle.x && mousePos.x < (rectangle.x + rectangle.width) && mousePos.y > rectangle.y && mousePos.y < (rectangle.y + rectangle.height))
        {
            if (state < dureeAffichage)
            {
                state+=10;
                animString();
            }
        }
        else
        {
            state = 0;
            textToDisplay = textTooltipFinal;

        }
       

    }

    void OnGUI()
    {
        GUI.skin = skin1;
        // Genere le button, le tooltip est con,fig par le label situe juste apres
        GUI.Button(rectangle, new GUIContent(textButton, textToDisplay));
        GUI.Label(new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y + 20, 200, 40), GUI.tooltip);

      
    }

    private string animString()
    {
        int tailleTotale = textTooltipFinal.Length;
        string stringRetour = "";
        int k = 0;
        for (int i = 0; i < state; i += (dureeAffichage / tailleTotale) + 1)
        {
            stringRetour += textTooltipFinal[k];
            k++;
        }
        int tailleAvantRand = stringRetour.Length;
        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (state % 6 == 0)
                lastChar = (char)Random.Range(97, 124);

            stringRetour += lastChar;
            stringRetour += '█';
        }
        textToDisplay = stringRetour;
        return stringRetour;
    }
}
