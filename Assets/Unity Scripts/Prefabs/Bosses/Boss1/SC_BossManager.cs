using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_BossManager : MonoBehaviour {

    void Start()
    {
        hardShip = PlayerPrefs.GetFloat("Hardship");
        fltHealPoints *= PlayerPrefs.GetFloat("Hardship");
        scorePoints *= PlayerPrefs.GetFloat("Hardship");
        blnDead = false;
        objSourge = GetComponentInParent<SC_SourgeBoss>();
    }

    void Update()
    {
        healtManager();
        if (fltHealPoints <= 1 && !blnDead) 
		{
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SC_PlayerShip>().PlayerScore(scorePoints);
            }

            foreach (Transform childen in GetComponentsInChildren<Transform>())
            {
                if (childen != transform)
                {
                    Destroy(childen.gameObject);
                }
            }

            this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.5f, GameObject.Find("Game Camera"));
            GameObject activeEM = Instantiate(explotion, this.transform.position, this.transform.rotation);
            activeEM.transform.localScale = bossSize;
            Destroy(activeEM, 2);
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
        if (coll.gameObject.tag == "Meteor")
        {
            coll.gameObject.GetComponent<SC_Meteor>().Dead(this.transform.parent);
        }
        if (coll.gameObject.tag == "Player Laser")
        {
            this.GetComponent<SC_AudioManager>().PlayAudio(1, 0.2f);
            fltincomingDamageH += coll.gameObject.GetComponent<SC_LaserPlayer>().Damage;
            this.GetComponent<SC_HitAnimation>().AColorAux = 135;

            Vector3 plasmaPosition = new Vector3(coll.transform.position.x, coll.transform.position.y, -14);
            Quaternion plasmaRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            GameObject plasma = Instantiate(plasmaShock, plasmaPosition, plasmaRotation);
            plasma.transform.SetParent(transform);
            Destroy(plasma, 1);

            Destroy(coll.gameObject);
        }
    }

    private void healtManager()
    {
        incoming = fltincomingDamageH * 0.66666666667f;
        if (fltincomingDamageH > 0)
        {
            fltHealPoints -= Time.deltaTime * incoming;
            fltincomingDamageH -= Time.deltaTime * incoming;
        }
        else if(fltincomingDamageH < fltincomingDamageH * 0.01f) fltincomingDamageH = 0;
        if (fltHealPoints < 1) fltHealPoints = 0;
        objSourge.IdBosses[idBoss] = fltHealPoints;
    }
    
    private float fltincomingDamageH;
    private bool blnDead;
    private float incoming;
    private GameObject activeEM;
    private SC_SourgeBoss objSourge;

    public int idBoss;
    public float fltHealPoints;
    public float scorePoints;
    public float hardShip;
	public float HealPoints { get { return fltHealPoints; } }
    public GameObject explotion;
    public GameObject plasmaShock;
    public Vector3 bossSize;
}
