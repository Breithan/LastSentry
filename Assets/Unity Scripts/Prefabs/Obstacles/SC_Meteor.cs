using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SC_Meteor : MonoBehaviour
{
    public float damage;
    public float scorePoints;
    public float healPoints;
    public float flt_MetVel; // Velocidad del Meteoro
    public Vector3 meteorSize;
    public Vector3 meteorVel;
    public GameObject bgdPurple;
    public GameObject explotion;
    public GameObject plasmaShock;

    // Devuelve el valor de la velocidad del objeto.
    public Vector3 MeteorVel { get { return meteorVel; } }

    // Devuelve el valor del daño físico del objeto.
    public float Damage { get { return damage; } set { damage = value; } }

    // Establece los puntos de salud del objeto.
    public float HealPoints { set { healPoints = value; } }

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
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(flt_MetVel + flt_MetVel * 0.5f));
        }

        if (healPoints <= 0)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SC_PlayerShip>().PlayerScore(scorePoints);
            }
            DestroyObject(this.transform);
        }
    }

    // Detector de colisiones.
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player Laser") {
            GetComponent<SC_HitAnimation>().AColorAux = 135;
            healPoints -= coll.gameObject.GetComponent<SC_LaserPlayer>().Damage;

            Vector3 plasmaPosition = new Vector3(coll.transform.position.x, coll.transform.position.y, -14);
            Quaternion plasmaRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            GameObject plasma = Instantiate(plasmaShock, plasmaPosition, plasmaRotation);
            this.GetComponent<SC_AudioManager>().PlayAudio(1, 0.2f);
            plasma.transform.SetParent(transform);
            Destroy(plasma, 1);

            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Meteor") { healPoints = 0; }
    }

    public void Dead (Transform parent)
    {
        this.transform.parent = parent;
        DestroyObject(parent);
    }

    public void DestroyObject(Transform parent)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -(flt_MetVel + flt_MetVel * 0.5f) / 1.5f);
        this.GetComponent<SC_AudioManager>().PlayAudio(0, 0.75f);
        GameObject activeEM = Instantiate(explotion, this.transform.position, this.transform.rotation);
        activeEM.transform.localScale = meteorSize;
        activeEM.transform.SetParent(parent);
        Destroy(GetComponent<PolygonCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(activeEM, 2);
        Destroy(this.gameObject, 2);
        Destroy(this);
    }

    public void Size(float randomSize)
    {
        float newSize = meteorSize.x - (0.9f - randomSize);
        meteorSize = new Vector3 (newSize, newSize, newSize);
        healPoints *= randomSize;
    }
}
