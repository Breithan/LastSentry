using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_HealAnim : MonoBehaviour {

	private Image Bar;
    public float Aux;

	void Start () 
	{
        Aux = 255;
		Bar = GetComponent<Image>();
	}
	
	void Update () 
	{
		Bar.color = new Color(Bar.color.r, Bar.color.g, Bar.color.b, Aux / 255);
		if (Aux < 255) Aux += 200 * Time.deltaTime;
		else Aux = 255;
	}

	public void GoAnimation() 
	{
		if(Aux == 255) Aux = 64;
	}
}
