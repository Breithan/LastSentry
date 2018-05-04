using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Ending : MonoBehaviour {

    // Privados
    public  GameObject  StartMenu_GamObj;
    private SpriteRenderer[] Sprites_SprRen;
    private Image[] Images_Ima;
    private Text[] Texts_Tex;
    private float PivoteAlfa_Flo;
    private float Alfa_Flo;
    private float[] SalveAlfa_Flo;
    private bool DestroyEscene;

    // Propiedades
    public GameObject StartMenu { set { StartMenu_GamObj = value; } }

    // Públicos
    public SpriteRenderer[] Backgrounds_SprRen;
    public bool Index;

    public void MyStart ( GameObject startMenu, bool index, bool destroyEscene ) {

        if (index) {

            DestroyEscene = destroyEscene;
            PivoteAlfa_Flo = 255;

        }

        else {

            PivoteAlfa_Flo = 0;

        }
        
        Alfa_Flo = 0;
        Backgrounds_SprRen = GetComponentsInChildren<SpriteRenderer>();

        StartMenu_GamObj = startMenu;
        Sprites_SprRen = StartMenu_GamObj.GetComponentsInChildren<SpriteRenderer>();
        Images_Ima = StartMenu_GamObj.GetComponentsInChildren<Image>();
        Texts_Tex = StartMenu_GamObj.GetComponentsInChildren<Text>();

        SalveAlfa_Flo = new float[Sprites_SprRen.Length];

        for (int i = 0; i < Sprites_SprRen.Length; i++) {

            SalveAlfa_Flo[i] = Sprites_SprRen[i].color.a;
            Sprites_SprRen[i].color = new Color(Sprites_SprRen[i].color.r, Sprites_SprRen[i].color.g, Sprites_SprRen[i].color.b, 0);

        }

        foreach (Image i in Images_Ima) {

            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        }

        foreach (Text i in Texts_Tex) {

            i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        }

    } 

	void Start () {
        
        if (Index) {

            MyStart(StartMenu_GamObj, true, false);

        }

    }
	
	void Update () {

        if (PivoteAlfa_Flo < 255) {

            FirstPaint();

        }

        else {

            SecondPaint();

        }

    }

    private void FirstPaint() {

        PivoteAlfa_Flo += 12;

        foreach (SpriteRenderer i in Backgrounds_SprRen)
        {

            i.color = new Color(i.color.r, i.color.g, i.color.b, PivoteAlfa_Flo / 255);

        }

    }

    private void SecondPaint() {

        if (Alfa_Flo < 255) {

            Alfa_Flo += 6;

            for (int i = 0; i < Sprites_SprRen.Length; i++) {

                Sprites_SprRen[i].color = new Color(Sprites_SprRen[i].color.r, Sprites_SprRen[i].color.g, Sprites_SprRen[i].color.b, (Alfa_Flo / 255) * SalveAlfa_Flo[i]);

            }

            foreach (Image i in Images_Ima) {

                i.color = new Color(i.color.r, i.color.g, i.color.b, Alfa_Flo / 255);

            }

            foreach (Text i in Texts_Tex) {

                i.color = new Color(i.color.r, i.color.g, i.color.b, Alfa_Flo / 255);

            }

        }

        else {

            Destroy(this);

        }

    }
}
