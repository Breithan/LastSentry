using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HitAnimation : MonoBehaviour
{
	public float AColorAux { get; set; }

    void Start()
	{
		AColorAux = 255;
	}

    void Update()
    {
        if (this.GetComponent<SpriteRenderer>() != null)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(AColorAux / 255, AColorAux / 255, AColorAux / 255);
            if (AColorAux < 255) AColorAux += 12;
            else AColorAux = 255;
        }
    }
}
