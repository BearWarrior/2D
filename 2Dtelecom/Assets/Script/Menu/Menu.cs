using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    private Rect rectMenu;

    private ButtonWithTooltip boutonJouer;
    private ButtonWithTooltip boutonOptions;
    private ButtonWithTooltip boutonQuitter;


    private ButtonWithTooltip boutonOptionsGraphiques;
    private ButtonWithTooltip boutonOptionsAudios;

    private GUISkin skin1; // GUI skin

    // Taille de l'image de fond
    private Vector2 imageFond;


    // Use this for initialization
    void Start()
    {
        skin1 = Resources.Load("Menu/Menu") as GUISkin;
        

        // rect De la fenetre principale, poura fficher l'image de fond et le texte principal
        rectMenu = new Rect(4 * Screen.width / 5 , 2* Screen.height / 3, 400, 100);

        //rect du 1er bouton
        boutonJouer = gameObject.AddComponent<ButtonWithTooltip>();
        boutonJouer.init("> Jouer", "Cliquez pour jouer !", new Rect(50,  Screen.height / 4, 200, 50), 1500);

        boutonOptions = gameObject.AddComponent<ButtonWithTooltip>();
        boutonOptions.init("> Options", "Options", new Rect(50, 2 * Screen.height / 4, 200, 50), 1500);

        boutonQuitter = gameObject.AddComponent<ButtonWithTooltip>();
        boutonQuitter.init("> Quitter", "Retour sur le bureau", new Rect(50, 3 * Screen.height / 4, 200, 50), 1500);

        /*
        *   Sous menu options :
        */
        boutonOptionsGraphiques = gameObject.AddComponent<ButtonWithTooltip>();
        boutonOptionsGraphiques.init("> Options graphiques", "No tooltuip", new Rect(50 + Screen.width/3, Screen.height / 4, 400, 50), 1500);
        boutonOptionsGraphiques.setDisplayed(true);

        boutonOptionsAudios = gameObject.AddComponent<ButtonWithTooltip>();
        boutonOptionsAudios.init("> Options audios", "No tooltuip", new Rect(50 + Screen.width / 3, Screen.height / 3, 400, 50), 1500);
        boutonOptionsAudios.setDisplayed(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(boutonOptions.getIsClicked())
        {
            boutonOptionsAudios.setDisplayed(true);
            boutonOptionsAudios.setDisplayingAnim(true);
            boutonOptionsGraphiques.setDisplayed(true);
            boutonOptionsGraphiques.setDisplayingAnim(true);

        }
        else
        {
            boutonOptionsAudios.setDisplayed(false);
            boutonOptionsGraphiques.setDisplayed(false);
        }

        // Button1 : if souris dessus, afficher tooltip; snon, pas afficher, et remettre compteur a 0
       
    }


    void OnGUI()
    {
        GUI.skin = skin1;
        // Box prionc + ecran
         GUI.Box(rectMenu, "MENU");
        
    }



}



