using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossHT : MonoBehaviour {
	
	void Update () 
	{
        if (healPoints <= 1) 
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SC_PlayerShip>().PlayerScore(scorePoints);
            }
            activeEM = Instantiate(explotion, this.transform.position, this.transform.rotation);
			Destroy(activeEM, 0.413f);
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<SC_PlayerShip>().healPoints = 0;
            this.GetComponent<SC_HitAnimation>().AColorAux = 135;
        }
        if (coll.gameObject.tag == "Player Laser")
        {
            healPoints -= coll.gameObject.GetComponent<SC_LaserPlayer>().Damage;
            this.GetComponent<SC_HitAnimation>().AColorAux = 135;
            Destroy(coll.gameObject);
        }
    }

    #region Atributos
    private GameObject activeEM;
    #endregion

    #region Propiedades
    public float healPoints;
	public float scorePoints;
    public GameObject explotion;
    #endregion
}
