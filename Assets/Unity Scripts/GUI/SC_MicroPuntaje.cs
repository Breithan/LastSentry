using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_MicroPuntaje : MonoBehaviour {

    private Canvas Canvas;
    private Text Text;
    private float Color;
    private float Alfa;

    public float Puntaje { private get; set; }

	private void Start () {

        // Puntaje
        Text = GetComponentInChildren<Text>();

        // Camara
        Canvas = GetComponentInChildren<Canvas>();
        Canvas.worldCamera = GameObject.Find("Game Camera").GetComponent<Camera>();

        // Color
        Alfa = 255;
        Color = Alfa / 255;
        Text.color = new Color(Color, Color, Color, Color);
        InvokeRepeating("Fade", 0, 0.1f);

    }

    void Update () {

        Text.text = ( (int) Puntaje).ToString();

	}

    public void Fade() {
        
        if (Alfa < 0) {

            Alfa = 0;

        }

        else {

            Alfa -= 20;

        }

        Color = Alfa / 255;

        Text.color = new Color(Color * 2, Color * 2, Color * 2, Color);

    }
}
