using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Oscilacion : MonoBehaviour {

	public float flt_Positi; // Posicion
	public float flt_Incomi; // Incremento de posicion
	public float flt_Pivote;
	public float flt_Oscila;
	public float Oscila { get { return flt_Oscila; } set { flt_Oscila = value; } }

	void Start ()
	{
		if (GameObject.FindGameObjectWithTag("Boss") == null)
		{
			Go();
		}
	}

	public void Go ()
	{
		flt_Positi = this.transform.position.y;
        flt_Incomi = 0;
        flt_Pivote = 0.005f;
	}

	private void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null)
            InStartMenu();

        else
            InGameStart();
    }

    private void InGameStart()
    {
        if (flt_Positi != 0 && GameObject.Find("cvsGameUI").GetComponent<SC_GameGUI>().Pause)
        {
            if (flt_Incomi >= 0.5f || flt_Incomi <= -0.5f)
                flt_Pivote *= -1;

            flt_Incomi += flt_Pivote;

            this.transform.position = new Vector3(this.transform.position.x, flt_Positi + (flt_Incomi * flt_Oscila), transform.position.z);
        }
    }

    private void InStartMenu()
    {
        if (flt_Incomi >= 0.5f || flt_Incomi <= -0.5f)
            flt_Pivote *= -1;

        flt_Incomi += flt_Pivote;

        this.transform.position = new Vector3(this.transform.position.x, flt_Positi + (flt_Incomi * flt_Oscila), transform.position.z);
    }
}
