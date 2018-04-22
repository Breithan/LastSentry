using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Attract : MonoBehaviour {

	private string str_TypAtt;
    public Vector3 targetPosition;
	private Transform vctPlayerTransform;

	void Start () 
	{
		str_TypAtt = this.gameObject.tag;
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			vctPlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();		
		}
	}
	
	void Update () 
	{
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
			if (str_TypAtt == "Power Up" || PlayerPrefs.GetFloat("Hardship") <= 1) 
			{
                targetPosition = vctPlayerTransform.transform.position;
                Vector3 itemPos = new Vector3(transform.position.x, transform.position.y, 0);
                transform.position = Vector3.MoveTowards(itemPos, targetPosition, Time.deltaTime * 2);
			}

			else 
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -PlayerPrefs.GetFloat("Hardship") * 1.5f);
			}
        }
	}
}
