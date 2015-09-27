using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuOptionsGraphiques : MonoBehaviour {
    
    public float shadowDrawDistance;
    public int ResX;
    public int ResY;
    public bool Fullscreen;

    private int nbOptions;



    private ButtonWithTooltip boutonRetour;

    private bool[] stateMenu; // if menu displayed or not 0 : Quality, 1 : AA, 2 : Buffer, 3 : Res, 4 : Aniso, 5 : ...
    private bool[] lastStateButton; // 0 : Quality, 1 : AA, 2 : Buffer, 3 : Res, 4 : Aniso, 5 : ...
    private List<ButtonWithTooltip>[] listBoutonSecondaires; // bouton associé aux diff options
    private ButtonWithTooltip[] listBoutonPrimaires;

    private string skinPath;
    private GUISkin skin1;

    private OptionMenu[] tabOption;




    // Use this for initialization
    void Start()
    {

       nbOptions = 5;
       tabOption = new OptionMenu[nbOptions];
       for (int i = 0; i < tabOption.Length; i++)
           tabOption[i] = new OptionMenu();

        stateMenu = new bool[nbOptions];
        for (int i = 0; i < stateMenu.Length; i++)
            stateMenu[i] = false;

        lastStateButton = new bool[nbOptions];
        for (int i = 0; i < lastStateButton.Length; i++)
            lastStateButton[i] = false;

        listBoutonSecondaires = new List<ButtonWithTooltip>[nbOptions];
        for (int i = 0; i < nbOptions; i++)
            listBoutonSecondaires[i] = new List<ButtonWithTooltip>();
        listBoutonPrimaires = new ButtonWithTooltip[nbOptions];




        skinPath = "Menu/MenuOptionsGraphiques";
        skin1 = Resources.Load(skinPath) as GUISkin;

        /*
        * Quality buttons
        */
        tabOption[0].boutonPrinc = genereButtonForOptionMenu(new ButtonWithTooltip(), "> Graphics quality", "Low, medium or high", new Rect(50, 1 * Screen.height / 6 - 50, 400, 50));
        tabOption[0].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> Low", "High performance (or crappy comp - lol)", new Rect(Screen.width * 2 / 3, 2 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[0].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> Medium", " ", new Rect(Screen.width * 2 / 3, 3 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[0].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> High", "Lower performance", new Rect(Screen.width * 2 / 3, 4 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[0].fctOpt.Add(setQualityLow);
        tabOption[0].fctOpt.Add(setQualityMedium);
        tabOption[0].fctOpt.Add(setQualityHigh);




        /*
        * AntiAliasing Buttons
        */
        tabOption[1].boutonPrinc = genereButtonForOptionMenu(new ButtonWithTooltip(), "> AntiAliasing", "None, 2x, 4x...", new Rect(50, 2 * Screen.height / 6 - 50, 400, 50));
        tabOption[1].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> On", "On", new Rect(Screen.width * 2 / 3, 2 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[1].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> Off", "Off", new Rect(Screen.width * 2 / 3, 3 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[1].fctOpt.Add(setAAOn);
        tabOption[1].fctOpt.Add(setAAOff);
   


        /*
        * Buffering buttons
        */
        tabOption[2].boutonPrinc = genereButtonForOptionMenu(new ButtonWithTooltip(), "> Triple Buffering", "ON/OFF", new Rect(50, 3 * Screen.height / 6 - 50, 400, 50));
        tabOption[2].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> On", "On", new Rect(Screen.width * 2 / 3, 2 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[2].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> Off", "Off", new Rect(Screen.width * 2 / 3, 3 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[2].fctOpt.Add(setBufferingOn);
        tabOption[2].fctOpt.Add(setBufferingOff);

        /*
        * Resolution Buttons
        */

        tabOption[3].boutonPrinc = genereButtonForOptionMenu(new ButtonWithTooltip(), "> Resolution", "HD, FullHD...", new Rect(50, 4 * Screen.height / 6 - 50, 400, 50));
        tabOption[3].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> 480p (640*480)", " ", new Rect(Screen.width * 2 / 3, 2 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[3].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> 720p (1280*720)", "HD", new Rect(Screen.width * 2 / 3, 3 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[3].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> 1080p (1920*1080)", "FullHD", new Rect(Screen.width * 2 / 3, 4 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[3].fctOpt.Add(setRes480p);
        tabOption[3].fctOpt.Add(setRes720p);
        tabOption[3].fctOpt.Add(setRes1080p);



        /*
        * Anisotropic Buttons
        */
        tabOption[4].boutonPrinc = genereButtonForOptionMenu(new ButtonWithTooltip(), "> Anisotropic filtering", "ON/OFF", new Rect(50, 5 * Screen.height / 6 - 50, 600, 50));
        tabOption[4].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> On", "On", new Rect(Screen.width * 2 / 3, 2 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[4].boutonsSec.Add(genereButtonForOptionMenu(new ButtonWithTooltip(), "> Off", "Off", new Rect(Screen.width * 2 / 3, 3 * Screen.height / 6 - 50, 400, 50), false));
        tabOption[4].fctOpt.Add(setAnisoOn);
        tabOption[4].fctOpt.Add(setAnisoOff);


        boutonRetour = genereButtonForOptionMenu(boutonRetour, "<- Retour", "Retourner au menu principal", new Rect(Screen.width - 350, 5 * Screen.height / 6, 300, 50));


    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = skin1;

        if(boutonRetour.getIsClicked())
            Application.LoadLevel("Menu");

        for(int i =0; i < nbOptions; i++)
        {
            int k = 0;
            foreach(ButtonWithTooltip b in tabOption[i].boutonsSec)
            {
                if (b.getState())
                    tabOption[i].fctOpt[k]();
                k++;
            }
            bool etatTemporaire = tabOption[i].state;
             if ( tabOption[i].boutonPrinc.getState())
            {
                OptionMenu.HideAllBoutonsSec(tabOption);
                tabOption[i].state = !etatTemporaire;
                if (!etatTemporaire)
                {
                    Debug.Log("insaide");

                    foreach (ButtonWithTooltip b in tabOption[i].boutonsSec)
                    {
                        b.setDisplayed(true);
                        b.setDisplayingAnim(true);
                    }
                }
                
            }
        }
        /*
            //INCREASE QUALITY PRESET
            if (GUI.Button(new Rect(810, 100, 300, 100), "Increase Quality"))
            {
                QualitySettings.IncreaseLevel();
                Debug.Log("Increased quality");
            }
            //DECREASE QUALITY PRESET
            if (GUI.Button(new Rect(810, 210, 300, 100), "Decrease Quality"))
            {
                QualitySettings.DecreaseLevel();
                Debug.Log("Decreased quality");
            }
            //0 X AA SETTINGS
            if (GUI.Button(new Rect(810, 320, 65, 100), "No AA"))
            {
                QualitySettings.antiAliasing = 0;
                Debug.Log("0 AA");
            }
            //2 X AA SETTINGS
            if (GUI.Button(new Rect(879, 320, 65, 100), "2x AA"))
            {
                QualitySettings.antiAliasing = 2;
                Debug.Log("2 x AA");
            }
            //4 X AA SETTINGS
            if (GUI.Button(new Rect(954, 320, 65, 100), "4x AA"))
            {
                QualitySettings.antiAliasing = 4;
                Debug.Log("4 x AA");
            }
            //8 x AA SETTINGS
            if (GUI.Button(new Rect(1028, 320, 65, 100), "8x AA"))
            {
                QualitySettings.antiAliasing = 8;
                Debug.Log("8 x AA");
            }
            //TRIPLE BUFFERING SETTINGS
            if (GUI.Button(new Rect(810, 430, 140, 100), "Triple Buffering On"))
            {
                QualitySettings.maxQueuedFrames = 3;
                Debug.Log("Triple buffering on");
            }
            if (GUI.Button(new Rect(955, 430, 140, 100), "Triple Buffering Off"))
            {
                QualitySettings.maxQueuedFrames = 0;
                Debug.Log("Triple buffering off");
            }
            //ANISOTROPIC FILTERING SETTINGS
            if (GUI.Button(new Rect(190, 100, 300, 100), "Anisotropic Filtering On"))
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                Debug.Log("Force enable anisotropic filtering!");
            }
            if (GUI.Button(new Rect(190, 210, 300, 100), "Anisotropic Filtering Off"))
            {
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                Debug.Log("Disable anisotropic filtering!");
            }
            //RESOLUTION SETTINGS
            //60Hz
            if (GUI.Button(new Rect(190, 320, 300, 100), "60Hz"))
            {
                Screen.SetResolution(ResX, ResY, Fullscreen, 60);
                Debug.Log("60Hz");
            }
            //120Hz
            if (GUI.Button(new Rect(190, 430, 300, 100), "120Hz"))
            {
                Screen.SetResolution(ResX, ResY, Fullscreen, 120);
                Debug.Log("120Hz");
            }
            //1080p
            if (GUI.Button(new Rect(500, 430, 93, 100), "1080p"))
            {
                Screen.SetResolution(1920, 1080, Fullscreen);
                ResX = 1920;
                ResY = 1080;
                Debug.Log("1080p");
            }
            //720p
            if (GUI.Button(new Rect(596, 430, 93, 100), "720p"))
            {
                Screen.SetResolution(1280, 720, Fullscreen);
                ResX = 1280;
                ResY = 720;
                Debug.Log("720p");
            }
            //480p
            if (GUI.Button(new Rect(692, 430, 93, 100), "480p"))
            {
                Screen.SetResolution(640, 480, Fullscreen);
                ResX = 640;
                ResY = 480;
                Debug.Log("480p");
            }
            if (GUI.Button(new Rect(500, 0, 140, 100), "Vsync On"))
            {
                QualitySettings.vSyncCount = 1;
            }
            if (GUI.Button(new Rect(645, 0, 140, 100), "Vsync Off"))
            {
                QualitySettings.vSyncCount = 0;
            }
            */

        GUI.Box(new Rect(7 *Screen.width / 10, 2 * Screen.height / 3, 450, 100), "Graphics options");
    }

    private ButtonWithTooltip genereButtonForOptionMenu(ButtonWithTooltip b, string textButt, string textTooltip, Rect r, bool toDisplay = true, int durationAnim = 1500)
    {
        b = gameObject.AddComponent<ButtonWithTooltip>();
        b.init(textButt, textTooltip, r, durationAnim);
        b.setAnimatedDisplayNum(2);
        b.setDisplayingAnim(true);
        b.setDisplayed(toDisplay);

        return b;
    }

    private static void setQualityHigh()
    {
        QualitySettings.SetQualityLevel(5);
    }

    private static void setQualityMedium()
    {
        QualitySettings.SetQualityLevel(3);
    }

    private static void setQualityLow()
    {
        QualitySettings.SetQualityLevel(1);
    }

    private static void setAAOn()
    {
        QualitySettings.antiAliasing = 8;
    }

    private static void setAAOff()
    {
        QualitySettings.antiAliasing = 0;
    }

    private static void setBufferingOn()
    {
        QualitySettings.maxQueuedFrames = 3;
    }

    private static void setBufferingOff()
    {
        QualitySettings.maxQueuedFrames = 0;
    }

    private static void setAnisoOn()
    {
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
    }

    private static void setAnisoOff()
    {
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
    }

    private static void setRes480p()
    {
        Screen.SetResolution(640, 480, false);
    }

    private static void setRes720p()
    {
        Screen.SetResolution(1280, 720, false);
    }

    private static void setRes1080p()
    {
        Screen.SetResolution(1920, 1080, false);
    }

}
