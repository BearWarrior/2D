using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private Rect rectBox;

    private ButtonWithTooltip boutonJouer;
    private ButtonWithTooltip boutonOptions;
    private ButtonWithTooltip boutonQuitter;

    private GUISkin skin1; // GUI skin

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
        boutonJouer = gameObject.AddComponent<ButtonWithTooltip>();
        boutonJouer.init("> Jouer", "Cliquez pour jouer !", new Rect(50,  Screen.height / 4, 200, 50), 1500);

        boutonOptions = gameObject.AddComponent<ButtonWithTooltip>();
        boutonOptions.init("> Options", "Options", new Rect(50, 2 * Screen.height / 4, 200, 50), 1500);

        boutonQuitter = gameObject.AddComponent<ButtonWithTooltip>();
        boutonQuitter.init("> Quitter", "Retour sur le bureau", new Rect(50, 3 * Screen.height / 4, 200, 50), 1500);
        //skin1 = Resources.Load("Menu/Menu") as GUISkin;
    }

    // Update is called once per frame
    void Update()
    {


        // Button1 : if souris dessus, afficher tooltip; snon, pas afficher, et remettre compteur a 0
       
    }


    void OnGUI()
    {
        GUI.skin = skin1;
        // Box prionc + ecran
         GUI.Box(rectBox, "MENU");
        
    }



}



