﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_SourgeBoss : MonoBehaviour {

    void Start()
    {

        foreach (float i in IdBosses)
        {
            healtPoints += i;
        }

        healthBar = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().BossBar;
        healthBar.gameObject.SetActive(true);
        healthBar.maxValue = healtPoints * PlayerPrefs.GetFloat("Hardship");
        blnDead = false;
    }

    void Update()
    {
        healtPoints = 0;
        foreach (float i in IdBosses)
        {
            healtPoints += i;
        }

        healthBar.value = (int)healtPoints;
        healthBar.GetComponentInChildren<Text>().text = "Boss HP: " + (int)healtPoints;

        if (healtPoints <= 1 && !blnDead)
        {
            if (SpacialStation != null) SpacialStation.transform.SetParent(GameObject.Find("SpawnManager").transform);
            healthBar.gameObject.SetActive(false);
            int oleada = GameObject.Find("SpawnManager").GetComponent<SC_Spawns>().Oleada;
            if (oleada == 5 && GameObject.FindGameObjectWithTag("Player") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<SC_PU05>());
            }
            else Instantiate(PowerUp, new Vector3(0, 10.25f), this.transform.rotation);

            if (finalBoss) {

                GameObject End = Instantiate(End_Backgraund);
                GameObject EndMenu = Instantiate(End_Menu);
                EndMenu.GetComponent<Canvas>().worldCamera = GameObject.Find("Game Camera").GetComponent<Camera>();
                End.GetComponent<SC_Ending>().MyStart(EndMenu, false, true);

            }

            Destroy(this.gameObject, 1);
            blnDead = true;
        }
    }

    // Atributos
    private float fltincomingDamageH;
    private bool blnDead;

    // Propiedades
    public GameObject PowerUp;
    public GameObject SpacialStation;
    public GameObject End_Backgraund;
    public GameObject End_Menu;
    public bool finalBoss;
    public Slider healthBar;
    public float[] hpBosses;
    public float[] IdBosses { get { return hpBosses; } set { hpBosses = value; } }
    public float healtPoints;
    public float IncomingDamageH { get { return fltincomingDamageH; } set { fltincomingDamageH = value; } }
    public float HealPoints { set { healtPoints = value; } }
}
