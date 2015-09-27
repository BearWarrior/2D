using UnityEngine;
using System.Collections;

using UnityEditor;

public class ButtonWithTooltip : MonoBehaviour
{


    public Rect rectangle; //Rectangle

    private string textTooltipToDisplay; // Variable stockant le texte a afficher, modifier par la fct animString
    private string textButtonToDisplay;
    public string textTooltipFinal; // Texte du Tooltip
    public string textButtonFinal; // Texte du Button

    private bool stateButton;
    private bool isClicked; // Si quelqu'un a clicker sur lez bouton (doit recliquer pour reapsser a true)
    private bool displayed; // True : affiche le bouton | false : n'affiche pas
    private char lastChar; // dernier charac stocke pour random pas trop rapide
    private char[] lastChars; // Stock la chaine de char pour l'an,im 2

    private int dureeAffichage; // duree de l'affichag, defaut : 1500
    private bool displayingAnim; // Si une animatoon est en cours d'affichage

    private int animNumero = 1; // numero de l'animation (currently : 1 et 2)

    private int stateTooltip; // Etat de l'ecriture du striong allant dfe 1 a dureeAffich pour le tooltip
    private int stateAnimatedDisplay; // Etat de l'animation pour le text quand displayingAnim = true

    private GUISkin skin1;

    
    //Constructeur
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
        lastChars = new char[100];
        stateButton = false;
    }

    public ButtonWithTooltip()
    { }

    //initialisatiuon, car buttonWithTooltip call with .addComponent

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
        lastChars = new char[100];
        stateButton = false;

    }


    // Use this for initialization
    void Start()
    {
        if (EditorApplication.currentScene.ToString().Contains("Options"))
            skin1 = Resources.Load("Menu/MenuOptionsgraphiques") as GUISkin;
        else
            skin1 = Resources.Load("Menu/Menu") as GUISkin;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos;
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        // If d'affichage du tooltip
        if (mousePos.x > rectangle.x && mousePos.x < (rectangle.x + rectangle.width) && mousePos.y > rectangle.y && mousePos.y < (rectangle.y + rectangle.height))
        {
            if (stateTooltip < dureeAffichage)
            {
                stateTooltip += 10;
                animStringTooltip();
            }
        }
        else
        {
            stateTooltip = 0;
            textTooltipToDisplay = textTooltipFinal;

        }

        // IF d'affichage de l'anim
        if (displayingAnim)
        {
            // If affichage pas fini
            if (stateAnimatedDisplay < dureeAffichage)
            {
                stateAnimatedDisplay += 10;

                // If du choix de l'affichage
                if (animNumero == 2)
                    animatedDisplay2();
                else
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

        GUI.skin = skin1;
        if (displayed)
        {

            /*
            *   Check meilleur solution
            */ 
            // Genere le button, le tooltip est con,fig par le label situe juste apres
            if (stateButton = GUI.Button(rectangle, new GUIContent(textButtonToDisplay, textTooltipToDisplay)))
            {
                isClicked = !isClicked;
            }

            GUI.Label(new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y + 20, 200, 40), GUI.tooltip);
        }

    }


    //Animation du tooltip
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
    //animation 1 d'entree du texte
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

        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (stateAnimatedDisplay % 6 == 0)
            {
                lastChar = (char)Random.Range(97, 124);
            }
            stringRetour += lastChar;
            stringRetour += '█';
        }
        textButtonToDisplay = stringRetour;
    }

    //animation 2 d'entree du texte
    public void animatedDisplay2()
    {
        int tailleTotale = textButtonFinal.Length;
        string stringRetour = "";
        int k = 0;
        for (int i = 0; i < stateAnimatedDisplay; i += (dureeAffichage / tailleTotale) + 1)
        {
            stringRetour += textButtonFinal[k];
            k++;
        }

        //Random rnd = new Random();
        if (!(stringRetour.Length == tailleTotale))
        {
            if (stateAnimatedDisplay % 6 == 0)
                for (int i = 0; i < 100; i++)
                {
                    lastChars[i] = (char)Random.Range(97, 124);
                }
            stringRetour += '█';
            for (int i = k + 1; i < tailleTotale; i++)
            {
                stringRetour += lastChars[i];
            }
        }
        textButtonToDisplay = stringRetour;
    }

    public bool getIsClicked() { return isClicked; }
    public bool getState() { return stateButton; }
    public void setDisplayed(bool d) { displayed = d; }
    public void setDisplayingAnim(bool d) { displayingAnim = d; }
    public void setAnimatedDisplayNum(int n) { animNumero = n; }
}