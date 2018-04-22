using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy_Ships : MonoBehaviour {

    public float damage;
    public float scorePoints;
    public float healPoints;
    public float flt_MetVel; // Velocidad del Meteoro
    public Vector3 enemySize;
    public GameObject bgdPurple;
    public GameObject explotion;
    public GameObject plasmaShock;
    public float Damage { get { return damage; } set { damage = value; } }

    private void Start()
    {
        bgdPurple = GameObject.Find("bgdPurple");
        damage *= PlayerPrefs.GetFloat("Hardship");
        healPoints *= PlayerPrefs.GetFloat("Hardship");
        scorePoints *= PlayerPrefs.GetFloat("Hardship");
    }

    private void Update()
    {
        if (flt_MetVel != bgdPurple.GetComponent<SC_Background>().BackVel)
        {
            flt_MetVel = bgdPurple.GetComponent<SC_Background>().BackVel;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(flt_MetVel * 2));
        }

        if (healPoints <= 0)
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

            this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.75f, GameObject.Find("Game Camera"));
            GameObject activeEM = Instantiate(explotion, this.transform.position, this.transform.rotation);
            activeEM.transform.localScale = enemySize;
            activeEM.transform.SetParent(this.transform);
            Destroy(GetComponent<PolygonCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<SC_EnemyShot>());
            Destroy(activeEM, 2);
            Destroy(this.gameObject, 2);
            Destroy(this);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player Laser")
        {
            this.GetComponent<SC_AudioManager>().PlayAudio(1, 0.2f);
            GetComponent<SC_HitAnimation>().AColorAux = 135;
            healPoints -= coll.gameObject.GetComponent<SC_LaserPlayer>().Damage;

            Vector3 plasmaPosition = new Vector3(coll.transform.position.x, coll.transform.position.y, -14);
            Quaternion plasmaRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            GameObject plasma = Instantiate(plasmaShock, plasmaPosition, plasmaRotation);
            plasma.transform.SetParent(transform);
            Destroy(plasma, 1);

            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Meteor")
        {
            this.GetComponent<SC_HitAnimation>().AColorAux = 135;
            coll.gameObject.GetComponent<SC_Meteor>().Dead(this.transform);
        }
    }
}
