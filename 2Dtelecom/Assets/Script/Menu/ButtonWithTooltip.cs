using UnityEngine;
using System.Collections;

public class ButtonWithTooltip : MonoBehaviour {


    public Rect rectangle; //Rectangle

    private string textTooltipToDisplay; // Variable stockant le texte a afficher, modifier par la fct animString
    private string textButtonToDisplay;
    public string textTooltipFinal; // Texte du Tooltip
    public string textButtonFinal; // Texte du Button


    private bool isClicked;
    private bool displayed;
    private char lastChar; // dernier charac stocke pour random pas trop rapide

    private int dureeAffichage;
    private bool displayingAnim;
    private int stateTooltip; // Etat de l'ecriture du striong allant dfe 1 a dureeAffich
    private int stateAnimatedDisplay;

    private GUISkin skin1;

    public ButtonWithTooltip(string textButt, string textTooltip, Rect rectangleParam, int dureeAffichageParam = 1500)
    {
        textButtonFinal = textButt;
        textTooltipFinal = textTooltip;
        rectangle = rectangleParam;
        dureeAffichage = dureeAffichageParam;
        textTooltipToDisplay = "";
        textButtonToDisplay = textButtonFinal;
        stateTooltip = 0;
        stateAnimatedDisplay = 0;
        isClicked = false;
        displayed = true;
        displayingAnim = false;
    }

    public void init(string textButt, string textTooltip, Rect rectangleParam, int dureeAffichageParam = 1500)
    {
        textButtonFinal = textButt;
        textTooltipFinal = textTooltip;
        rectangle = rectangleParam;
        dureeAffichage = dureeAffichageParam;
        textTooltipToDisplay = "";
        textButtonToDisplay = textButtonFinal;
        stateTooltip = 0;
        stateAnimatedDisplay = 0;
        isClicked = false;
        displayed = true;
        displayingAnim = false;

    }


    // Use this for initialization
    void Start () {
        skin1 = Resources.Load("Menu/Menu") as GUISkin;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos;
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        // If d'affichage du tooltip
        if (mousePos.x > rectangle.x && mousePos.x < (rectangle.x + rectangle.width) && mousePos.y > rectangle.y && mousePos.y < (rectangle.y + rectangle.height))
        {
            if (stateTooltip < dureeAffichage)
            {
                stateTooltip+=10;
                animStringTooltip();
            }
        }
        else
        {
            stateTooltip = 0;
            textTooltipToDisplay = textTooltipFinal;

        }
       
        if(displayingAnim)
        {
            if (stateAnimatedDisplay < dureeAffichage)
            {
                stateAnimatedDisplay += 10;
                animatedDisplay();
            }
            else
                displayingAnim = false;
        }
        else
        {
            stateAnimatedDisplay = 0;
            textButtonToDisplay = textButtonFinal;
        }


    }

    void OnGUI()
    {
        if (displayed)
        {
            GUI.skin = skin1;
            // Genere le button, le tooltip est con,fig par le label situe juste apres
            if (GUI.Button(rectangle, new GUIContent(textButtonToDisplay, textTooltipToDisplay)))
            {
                isClicked = !isClicked;
            }
            GUI.Label(new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y + 20, 200, 40), GUI.tooltip);
        }
      
    }

    private string animStringTooltip()
    {
        int tailleTotale = textTooltipFinal.Length;
        string stringRetour = "";
        int k = 0;
        for (int i = 0; i < stateTooltip; i += (dureeAffichage / tailleTotale) + 1)
        {
            stringRetour += textTooltipFinal[k];
            k++;
        }
        int tailleAvantRand = stringRetour.Length;
        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (stateTooltip % 6 == 0)
                lastChar = (char)Random.Range(97, 124);

            stringRetour += lastChar;
            stringRetour += '█';
        }
        textTooltipToDisplay = stringRetour;
        return stringRetour;
    }

    public void animatedDisplay()
    {
        int tailleTotale = textButtonFinal.Length;
        string stringRetour = "";
        int k = 0;
        for (int i = 0; i < stateAnimatedDisplay; i += (dureeAffichage / tailleTotale) + 1)
        {
            stringRetour += textButtonFinal[k];
            k++;
        }
        int tailleAvantRand = stringRetour.Length;
        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (stateAnimatedDisplay % 6 == 0)
                lastChar = (char)Random.Range(97, 124);

            stringRetour += lastChar;
            stringRetour += '█';
        }
        textButtonToDisplay = stringRetour;
    }

    public bool getIsClicked() { return isClicked; }
    public void setDisplayed(bool d) { displayed = d; }
    public void setDisplayingAnim(bool d) { displayingAnim = d; }

}
